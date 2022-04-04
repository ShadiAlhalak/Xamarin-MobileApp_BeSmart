using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App11.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace App11
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LSTView);
            string Company = Intent.GetStringExtra("Company");
            Company = Company + ".json";
            string content;
            Android.Content.Res.AssetManager assets = this.Assets;
            //using (StreamReader sr = new StreamReader(assets.Open("Xiaomi.json")))
            using (StreamReader sr = new StreamReader(assets.Open(Company)))
            {
                content = sr.ReadToEnd();
            }
            List<MobileSpaceObject> json = JsonConvert.DeserializeObject<List<MobileSpaceObject>>(content);

            List<clsFullSpeac> mobFullSpec = new List<clsFullSpeac>();
            string MobileName = Intent.GetStringExtra("MobName");
            foreach (MobileSpaceObject mob in json)
            {
                //string NewName = null;

                //mob.Name = mob.Name.Replace("Xiaomi", "");
                //mob.Name = mob.Name.Replace("SamsungGalaxy", "");
                //foreach (char chr in mob.Name)
                //{
                //    if (char.IsUpper(chr))
                //    {
                //        NewName += " ";
                //    }
                //    NewName += chr;
                //}

                if (mob.Name == MobileName)
                {
                    //mobFullSpec.Add(EnhanceSpeacView.Display(mob));
                    // strings.app_name = "Xiaomi Redmi K50 Gaming";
                    mobFullSpec.Add(new clsFullSpeac("LAUNCH", "Announced", "Status", "", "", mob.Announced, mob.Status, "", ""));
                    mobFullSpec.Add(new clsFullSpeac("NETWORK", "Announced", "SIM", "", "", mob.Technology, mob.SIM, "", ""));
                    mobFullSpec.Add(new clsFullSpeac("BODY", "Dimensions", "Weight", "Build", "IP Rating", mob.Dimensions, mob.Weight, mob.Build, mob.IPRating));
                    mobFullSpec.Add(new clsFullSpeac("DISPLAY", "Type", "Size", "Resolution", "Protection", mob.Display_Type, mob.Display_Size, mob.Display_Resolution, mob.Display_Protection));
                    mobFullSpec.Add(new clsFullSpeac("PLATFORM", "OS", "Chipset", "CPU", "GPU", mob.OS, mob.Chipset, mob.CPU, mob.GPU));
                    mobFullSpec.Add(new clsFullSpeac("MEMORY", "Card Slot", "Internal", "", "", mob.Card_slot, mob.Internal, mob.Memory_Type, ""));
                    mobFullSpec.Add(new clsFullSpeac("CAMERA", "Main Camera", "Features", "Video", "", mob.MAIN_CAMERA, mob.Features, mob.Video, ""));
                    mobFullSpec.Add(new clsFullSpeac("SELFIE", "Front Camera", "Features", "Video", "", mob.SELFIE_CAMERA, mob.Selfie_Features, mob.Selfie_Video, ""));
                    mobFullSpec.Add(new clsFullSpeac("SOUND", "LoudSpeaker", "3.5mm Jack", "", "", mob.SOUND, mob.jack3mm, "", ""));
                    mobFullSpec.Add(new clsFullSpeac("COMMS", "WLAN", "Bluetooth", "GPS", "NFC", mob.WLAN, mob.Bluetooth, mob.GPS, mob.NFC));
                    mobFullSpec.Add(new clsFullSpeac("Feaures", "Sensor", "Infrared port", "Radio", "USB", mob.Sensors, mob.Infrared_port, mob.Radio, mob.USB));
                    mobFullSpec.Add(new clsFullSpeac("OTHER", "BATTERY", "Charging", "Colors", "Price", mob.BATTERY, mob.Charging, mob.Colors, mob.Price));
                }
            }

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new MYHomeScreenAdapter(this, mobFullSpec);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
    // adpater manage
    public class MYHomeScreenAdapter : BaseAdapter<clsFullSpeac>
    {
        List<clsFullSpeac> items;
        Activity context;
        public MYHomeScreenAdapter(Activity context, List<clsFullSpeac> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override clsFullSpeac this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.SpaceContainarCopy, null);
            view.FindViewById<TextView>(Resource.Id.txtTitle).Text = item.title;
            view.FindViewById<TextView>(Resource.Id.txt1).Text = item.txt1;
            view.FindViewById<TextView>(Resource.Id.txt2).Text = item.txt2;
            view.FindViewById<TextView>(Resource.Id.txt3).Text = item.txt3;
            view.FindViewById<TextView>(Resource.Id.txt4).Text = item.txt4;
            //    view.FindViewById<TextView>(Resource.Id.txt5).Text = item.txt5;
            view.FindViewById<TextView>(Resource.Id.val1).Text = item.val1;
            view.FindViewById<TextView>(Resource.Id.val2).Text = item.val2;
            view.FindViewById<TextView>(Resource.Id.val3).Text = item.val3;
            view.FindViewById<TextView>(Resource.Id.val4).Text = item.val4;
            //        view.FindViewById<TextView>(Resource.Id.val5).Text = item.val5;
            return view;
        }
    }
}