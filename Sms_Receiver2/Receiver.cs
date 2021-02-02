using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Telephony;
using Android.Provider;

namespace Sms_Receiver2
{
    [BroadcastReceiver(Label = "SMS Receiver")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class Receiver1 : BroadcastReceiver
    {
        public string message, address = "";
        public static readonly string INTENT_ACTION = "android.provider.Telephony.SMS_RECEIVED";
        public override void OnReceive(Context context, Intent intent)
        {

            if (intent.HasExtra("pdus"))
            {
                var smsArray = (Java.Lang.Object[])intent.Extras.Get("pdus");
                foreach (var item in smsArray)
                {
                    var sms = SmsMessage.CreateFromPdu((byte[])item);
                    address = sms.OriginatingAddress;
                    message = sms.MessageBody;
                    Toast.MakeText(context, "Number :" + address + "Message : " + message, ToastLength.Short).Show();

                }
            }

           
        }
    }
}