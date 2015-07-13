using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace VietBaIT.HISLink.UI.ControlUtility.BaseClass
{
    public class HISLISManager
    {
            public bool AutoStopWhenError = false;
            bool ClearItemsAfterFinished = false;
            public delegate void OnQueueChanged(int QueueCount);
            public event OnQueueChanged _OnQueueChanged;
            public delegate void Onfinished();
            public event Onfinished _Onfinished;
            public delegate void OnAction(int result, string MA_CHIDINH, int vAssign_Id, string PATIENT_CODE, string sLogText, Color resultColor);
            public event OnAction _OnAction;
            public delegate void OnDoing(string sLogText, Color resultColor);
            public event OnDoing _OnDoing;
            public HISLISManager()
            {

            }
             bool isSending = true;
             bool IsSuspending = false;
            Queue queue = new Queue();
            public void StartUp()
            {
                isSending = true;
                StartSending();
            }
            public void Stop()
            {
                queue.Clear();
                isSending = false;
            }
            public void AddItems2Queue(HISLISItem _newItem)
            {
                try
                {
                    if (!isSending)
                        StartUp();
                    queue.Enqueue(_newItem);
                }
                catch
                {
                }
            }
            
            public void StartSending()
            {
                try
                {
                    using (BackgroundWorker _BackgroundWorker = new BackgroundWorker())
                    {
                        _BackgroundWorker.WorkerReportsProgress = true;
                        _BackgroundWorker.WorkerSupportsCancellation = true;
                        _BackgroundWorker.DoWork += new DoWorkEventHandler(_BackgroundWorker_DoWork);
                        _BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_BackgroundWorker_ProgressChanged);
                        _BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_BackgroundWorker_RunWorkerCompleted);
                        if (!_BackgroundWorker.IsBusy)
                            _BackgroundWorker.RunWorkerAsync();
                    }
                }
                catch
                {
                }
            }

            void _BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                _Onfinished();
            }

            void _BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                try
                {
                }
                catch
                {
                }
            }

            void _BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    while (isSending)
                    {
                        Thread.Sleep(10);
                        if (!IsSuspending)
                        {
                            _OnQueueChanged(queue.Count);
                            if (queue.Count > 0)
                            {
                                HISLISItem item = queue.Dequeue() as HISLISItem;
                                item._OnAction += new HISLISItem.OnAction(item__OnAction);
                                item._OnDoing += new HISLISItem.OnDoing(item__OnDoing);
                                item.DoSend();
                                while (item.isSending)
                                    Application.DoEvents();
                                
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            void item__OnDoing(string sLogText, Color resultColor)
            {
                _OnDoing(sLogText, resultColor);
            }

            void item__OnAction(int result, string MA_CHIDINH, int vAssign_Id, string PATIENT_CODE, string sLogText, Color resultColor)
            {
                _OnAction(result,MA_CHIDINH, vAssign_Id, PATIENT_CODE, sLogText, resultColor);
            }
            
           

           
    }
}
