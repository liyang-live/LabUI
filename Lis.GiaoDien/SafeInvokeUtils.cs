using System;
using System.Reflection;
using System.Windows.Forms;

namespace Vietbait.Lablink.TestInformation.UI
{
    /// <summary>
    /// A helper class that allows to invoke control's 
    /// methods and properties thread-safely.
    /// </summary>
    public class SafeInvokeUtils
    {
        /// <summary>
        /// Delegate to invoke a specific method on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to invoke the method</param>
        /// <param name="methodName">Method to be invoked</param>
        /// <param name="paramValues">Method parameters</param>
        /// <returns>Value returned by the invoked method</returns>
        private delegate object MethodInvoker(Control control, string methodName, params object[] paramValues);

        /// <summary>
        /// Delegate to get a property value on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to GET the property value</param>
        /// <param name="propertyName">Property name</param>
        /// <return>Property value</return>
        private delegate object PropertyGetInvoker(Control control, string propertyName);

        /// <summary>
        /// Delegate to set a property value on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to SET the property value</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="value">New property value</param>
        private delegate void PropertySetInvoker(Control control, string propertyName, object value);

        /// <summary>
        /// Invoke a specific method on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to invoke the method</param>
        /// <param name="methodName">Method to be invoked</param>
        /// <param name="paramValues">Method parameters</param>
        /// <return>Value returned by the invoked method</return>
        public static object InvokeMethod(Control control, string methodName, params object[] paramValues)
        {
            if (control != null && !string.IsNullOrEmpty(methodName))
            {
                if (control.InvokeRequired)
                {
                    return control.Invoke(new MethodInvoker(InvokeMethod),
                                          control, methodName, paramValues);
                }
                else
                {
                    MethodInfo methodInfo = null;

                    if (paramValues != null && paramValues.Length > 0)
                    {
                        Type[] types = new Type[paramValues.Length];
                        for (int i = 0; i < paramValues.Length; i++)
                        {
                            if (paramValues[i] != null)
                            {
                                types[i] = paramValues[i].GetType();
                            }
                        }

                        methodInfo = control.GetType().GetMethod(methodName, types);
                    }
                    else
                    {
                        methodInfo = control.GetType().GetMethod(methodName);
                    }

                    if (methodInfo != null)
                    {
                        return methodInfo.Invoke(control, paramValues);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Get a PropertyInfo object associated with a specific property on the control.
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="propertyName">Property name</param>
        /// <return>A PropertyInfo object associated with 
        /// 'propertyName' on specified 'control'</return>
        private static PropertyInfo GetProperty(Control control, string propertyName)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo propertyInfo = control.GetType().GetProperty(propertyName);
                if (propertyInfo == null)
                {
                    throw new Exception(control.GetType().ToString() + " does not contain '" + propertyName +
                                        "' property.");
                }

                return propertyInfo;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Set a property value on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to SET the property value</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="value">New property value</param>
        public static void SetPropertyValue
            (Control control, string propertyName, object value)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new PropertySetInvoker
                                       (SetPropertyValue), control, propertyName, value);
                }
                else
                {
                    PropertyInfo propertyInfo = GetProperty(control, propertyName);
                    if (propertyInfo != null)
                    {
                        if (propertyInfo.CanWrite)
                        {
                            propertyInfo.SetValue(control, value, null);
                        }
                        else
                        {
                            throw new Exception(control.GetType().ToString() + "." + propertyName +
                                                " is read-only property.");
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Get a property value on the control thread-safely.
        /// </summary>
        /// <param name="control">Control on which to GET the property value</param>
        /// <param name="propertyName">Property name</param>
        /// <return>Property value</return>
        public static object GetPropertyValue(Control control, string propertyName)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
            {
                if (control.InvokeRequired)
                {
                    return control.Invoke(new PropertyGetInvoker(GetPropertyValue),
                                          control, propertyName);
                }
                else
                {
                    PropertyInfo propertyInfo = GetProperty(control, propertyName);
                    if (propertyInfo != null)
                    {
                        if (propertyInfo.CanRead)
                        {
                            return propertyInfo.GetValue(control, null);
                        }
                        else
                        {
                            throw new Exception(control.GetType().ToString() + "." + propertyName +
                                                " is write-only property.");
                        }
                    }

                    return null;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
