using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using App11.Classes;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.TextField;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
namespace App11
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        //search
        Boolean SearchFlag = false;
        List<MobSpec> SearchList = new List<MobSpec>();
        //
        TextView textMessage;
        string Company;
        List<MobSpec> mobSpec = new List<MobSpec>();
        List<clsNews> lstNews = new List<clsNews>();
        string content;
        Android.Content.Res.AssetManager assets;
        ListView MainlistView;
        NewsScreenAdapter ___homeadapter;
        HomeScreenAdapter PreviewSpeacAdapter;
        string CurrentTap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.RelativeMainActivity );

            assets = this.Assets;
            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

             MainlistView = FindViewById<ListView>(Resource.Id.listView1);

            lstNews.Add(new clsNews("iPhone 14 Pro instead of the notch", "The pill fits the wider hardware of Face ID, while the punch hole is for the single selfie camera.", Resource.Drawable.iphone));
            lstNews.Add(new clsNews("Samsung Galaxy A53 Event live here", "Samsung Galaxy A53 Come with Exynos 1200 and 64Mb Camera with OIS but without Charger.", Resource.Drawable.A53));
            lstNews.Add(new clsNews("Redmi K40S is a minor refresh of k40", "Xiaomi just brought the Redmi K40S to the Chinese market.", Resource.Drawable.K40s));
            lstNews.Add(new clsNews("Watch the Samsung Galaxy A Event live here", "Samsung is having an event today, where we expect to see the debut of the Galaxy A33, Galaxy A53 and Galaxy A73 or at least a subset of those.", Resource.Drawable.A3));
            lstNews.Add(new clsNews("Honor Magic4 Lite Annocend", "This appears to be based on the Honor X30 that launched in December. It will be much cheaper than the other two Magic4 models.", Resource.Drawable.honor));
            lstNews.Add(new clsNews("Redmi K50 series Annocend", "Redmi K50 series to bring 512GB storage, OIS for the 108MP camera ,120W Charger and more Flagship speac", Resource.Drawable.k50));

            mobSpec = new List<MobSpec>();
             ___homeadapter = new NewsScreenAdapter(this, lstNews);
            MainlistView.Adapter = ___homeadapter;
            MainlistView.ItemClick += ListView_ItemClick;

            ImageButton btnSearch = FindViewById<ImageButton>(Resource.Id.btnSearch);
            btnSearch.Click += BtnSearch_Click;    ;
            CurrentTap = "@string/title_home";

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TextInputEditText txtSearch = FindViewById<TextInputEditText>(Resource.Id.txtSearch);
            if (CurrentTap == "Home")
            {
                string txt = txtSearch.Text;

                List<clsNews> SearchlstNews = new List<clsNews>();
                foreach (clsNews news in lstNews)
                {
                    if (news.Title.ToString().Contains(txtSearch.Text))
                    {
                        SearchlstNews.Add(news);
                    }
                }
                NewsScreenAdapter adapter = new NewsScreenAdapter(this, SearchlstNews);
                MainlistView.Adapter = ___homeadapter;
            }
            else if (CurrentTap == "sam")
            {
                string txt= txtSearch.Text;
                txt = txt.Replace(" ", "");
                List<MobSpec> SearchMob = new List<MobSpec>();
                foreach (MobSpec mob in mobSpec)
                {
                    if (mob.MobName.ToString().ToLower().Contains(txt.ToLower()))
                    {
                        SearchMob.Add(mob);
                    }

                }
                HomeScreenAdapter searchAdapter =new HomeScreenAdapter(this, SearchMob);
                MainlistView.Adapter = searchAdapter;
                if (SearchMob.Count > 0)
                {
                    SearchFlag = true;
                    SearchList = SearchMob;
                }
                else
                {
                    SearchFlag = false;
                }
            }
            else if (CurrentTap == "mi")
            {
                string txt = txtSearch.Text;
                txt = txt.Replace(" ", "");
                List<MobSpec> SearchMob = new List<MobSpec>();
                    foreach (MobSpec mob in mobSpec)
                {
                    if (mob.MobName.ToString().ToLower().Contains(txt.ToLower()))
                    {
                            SearchMob.Add(mob);
                    }
                    HomeScreenAdapter searchAdapter = new HomeScreenAdapter(this, SearchMob);
                    MainlistView.Adapter = searchAdapter;
                    if (SearchMob.Count > 0)
                    {
                        SearchFlag = true;
                        SearchList = SearchMob;
                    }
                    else
                    {
                        SearchFlag = false;
                    }
                }
            }

                
            }

      

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    CurrentTap = "Home";
                    lstNews = new List<clsNews>();

                    lstNews.Add(new clsNews("iPhone 14 Pro instead of the notch", "The pill fits the wider hardware of Face ID, while the punch hole is for the single selfie camera.", Resource.Drawable.iphone));
                    lstNews.Add(new clsNews("Samsung Galaxy A53 Event live here", "Samsung Galaxy A53 Come with Exynos 1200 and 64Mb Camera with OIS but without Charger.", Resource.Drawable.A53));
                    lstNews.Add(new clsNews("Redmi K40S is a minor refresh of k40", "Xiaomi just brought the Redmi K40S to the Chinese market.", Resource.Drawable.K40s));
                    lstNews.Add(new clsNews("Watch the Samsung Galaxy A Event live here", "Samsung is having an event today, where we expect to see the debut of the Galaxy A33, Galaxy A53 and Galaxy A73 or at least a subset of those.", Resource.Drawable.A3));
                    lstNews.Add(new clsNews("Honor Magic4 Lite Annocend", "This appears to be based on the Honor X30 that launched in December. It will be much cheaper than the other two Magic4 models.", Resource.Drawable.honor));
                    lstNews.Add(new clsNews("Redmi K50 series Annocend", "Redmi K50 series to bring 512GB storage, OIS for the 108MP camera ,120W Charger and more Flagship speac", Resource.Drawable.k50));

                    mobSpec = new List<MobSpec>();
                    ListView __listView = FindViewById<ListView>(Resource.Id.listView1);
                    var __homeadapter = new NewsScreenAdapter(this, lstNews);
                    __listView.Adapter = __homeadapter;
                    //textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.samsung:
                    CurrentTap = "sam";
                    Company = "Samsung";
                    mobSpec = new List<MobSpec>();
                    using (StreamReader sr = new StreamReader(assets.Open("Samsung.json")))
                    {
                        content = sr.ReadToEnd();
                    }
                    List<MobileSpaceObject> json = JsonConvert.DeserializeObject<List<MobileSpaceObject>>(content);

                    List<clsFullSpeac> mobFullSpec = new List<clsFullSpeac>();

                    foreach (MobileSpaceObject mob in json)
                    {
                        string[] Cam = mob.MAIN_CAMERA.Split(",");
                        string[] dtype = mob.Display_Type.Split(",");
                        string[] dsize = mob.Display_Size.Split(",");
                        string[] batt = mob.BATTERY.Split(",");
                        string[] chip = mob.Chipset.Split(",");
                        string[] price = mob.Price.Split(";");
                        if (price[0].Contains("&"))
                        {
                            mobSpec.Add(new MobSpec(mob.Name, Resource.Drawable.sams, "Display : " + dtype[0] + "," + dsize[0], "Camera : " + Cam[0], "Battary : " + batt[0], "Processor : " + chip[0], "Price : " + price[2]));
                        }
                        else
                        {
                            mobSpec.Add(new MobSpec(mob.Name, Resource.Drawable.sams, "Display : " + dtype[0] + "," + dsize[0], "Camera : " + Cam[0], "Battary : " + batt[0], "Processor : " + chip[0], "Price : " + price[0]));
                        }
                    }

                    ListView listView = FindViewById<ListView>(Resource.Id.listView1);
                    var homeadapter = new HomeScreenAdapter(this, mobSpec);
                    listView.Adapter = homeadapter;

                    return true;
                case Resource.Id.xiaomi:
                    CurrentTap = "mi";
                    Company = "Xiaomi";
                    mobSpec = new List<MobSpec>();
                    //string content;
                    //Android.Content.Res.AssetManager assets = this.Assets;
                    using (StreamReader sr = new StreamReader(assets.Open("Xiaomi.json")))
                    {
                        content = sr.ReadToEnd();
                    }
                    List<MobileSpaceObject> _json = JsonConvert.DeserializeObject<List<MobileSpaceObject>>(content);

                    //List<clsFullSpeac> mobFullSpec = new List<clsFullSpeac>();

                    foreach (MobileSpaceObject mob in _json)
                    {
                        string[] Cam = mob.MAIN_CAMERA.Split(",");
                        string[] dtype = mob.Display_Type.Split(",");
                        string[] dsize = mob.Display_Size.Split(",");
                        string[] batt = mob.BATTERY.Split(",");
                        string[] chip = mob.Chipset.Split(",");
                        string[] price = mob.Price.Split(";");
                        if (price[0].Contains("&"))
                        {
                            mobSpec.Add(new MobSpec(mob.Name, Resource.Drawable.note11, "Display : " + dtype[0] + "," + dsize[0], "Camera : " + Cam[0], "Battary : " + batt[0], "Processor : " + chip[0], "Price : " + price[2]));
                        }
                        else
                        {
                            mobSpec.Add(new MobSpec(mob.Name, Resource.Drawable.note11, "Display : " + dtype[0] + "," + dsize[0], "Camera : " + Cam[0], "Battary : " + batt[0], "Processor : " + chip[0], "Price : " + price[0]));
                        }
                    }

                    ListView _listView = FindViewById<ListView>(Resource.Id.listView1);

                    //merge adapter 
                    // var _homeadapter = new HomeScreenAdapter(this, mobSpec);
                    //var _mergeadapter = new MergeAdapter();
                    // mergeadapter.AddAdapter(_adapter);
                    //_mergeadapter.AddAdapter(_homeadapter);
                    //_mergeadapter.SetNoItemText("No Item");
                    //_listView.Adapter = _mergeadapter;
                    //\merge adapter 

                    var _adapter = new HomeScreenAdapter(this, mobSpec);
                    _listView.Adapter = _adapter;
                    //_listView.ItemClick += ListView_ItemClick; 
                    return true;

            }
            return false;
        }
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try

            {
                var listView = sender as ListView;
                var t = mobSpec[e.Position];
                if (SearchFlag)
                {
                    t = SearchList[e.Position];
                }
                else
                {
                     t = mobSpec[e.Position];
                }
                var intent = new Intent(this, typeof(Activity1));
                intent.PutExtra("MobName", t.MobName);
                intent.PutExtra("Company", Company);
                StartActivity(intent);
            }
            catch (Exception ex)
            {
            }

        }
    }
    public class clsNews
    {
        public string Title;
        public string Body;
        public int Image;

        public clsNews(string title, string body, int image)
        {
            this.Title = title;
            this.Body = body;
            this.Image = image;
        }

    }
    public class HomeScreenAdapter : BaseAdapter<MobSpec>
    {
        List<MobSpec> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<MobSpec> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override MobSpec this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.Spacefactions, null);
            string NewName = null;
            string name = null;
            name = item.MobName;
            name = item.MobName.Replace("Xiaomi", "");
            name = item.MobName.Replace("SamsungGalaxy", "");
            foreach (char chr in name)
            {
                if (char.IsUpper(chr))
                {
                    NewName += " ";
                }
                NewName += chr;
            }
            view.FindViewById<TextView>(Resource.Id.txtMobName).Text = NewName;
            view.FindViewById<TextView>(Resource.Id.txtDis).Text = item.Display;
            view.FindViewById<TextView>(Resource.Id.txtCam).Text = item.Camera;
            view.FindViewById<TextView>(Resource.Id.txtProc).Text = item.Processor;
            view.FindViewById<TextView>(Resource.Id.txtPrice).Text = item.Price;
            view.FindViewById<TextView>(Resource.Id.txtBat).Text = item.Battary;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.ImageResourceId);
            return view;
        }

    }

    public class NewsScreenAdapter : BaseAdapter<clsNews>
    {
        List<clsNews> items;
        Activity context;
        public NewsScreenAdapter(Activity context, List<clsNews> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override clsNews this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.MainNewsCopy, null);

            view.FindViewById<TextView>(Resource.Id.txtTitle).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.txtBody).Text = item.Body;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.Image);
            return view;
        }

    }

    public class MergeAdapter : BaseAdapter
    {
        protected List<IListAdapter> pieces = new List<IListAdapter>();
        protected string noItemsText;

        public MergeAdapter()
        {
        }

        public void AddAdapter(IListAdapter adapter)
        {
            pieces.Add(adapter);
            adapter.RegisterDataSetObserver(new CascadeDataSetObserver());
        }

        private class CascadeDataSetObserver : DataSetObserver
        {
            public override void OnChanged()
            {
                base.OnChanged();
            }

            public override void OnInvalidated()
            {
                base.OnInvalidated();
            }
        }

        public override int Count
        {
            get
            {
                int total = 0;
                foreach (var piece in pieces)
                {
                    total += piece.Count;
                }
                if (total == 0 && noItemsText != null)
                {
                    total = 1;
                }
                return total;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return (piece.GetItem(position));
                position -= size;
            }
            return null;
        }

        public override int ViewTypeCount
        {
            get
            {
                int total = 0;
                foreach (var piece in pieces)
                {
                    total += piece.ViewTypeCount;
                }
                return (Java.Lang.Math.Max(total, 1));
            }
        }

        public override int GetItemViewType(int position)
        {
            int typeOffset = 0;
            int result = -1;

            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                {
                    result = typeOffset + piece.GetItemViewType(position);
                    break;
                }
                position -= size;
                typeOffset += piece.ViewTypeCount;
            }
            return result;
        }

        public override long GetItemId(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                {
                    return (piece.GetItemId(position));
                }
                position -= size;
            }
            return (-1);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return piece.GetView(position, convertView, parent);
                position -= size;
            }
            if (noItemsText != null)
            {
                TextView text = new TextView(parent.Context);
                text.Text = noItemsText;
                return text;
            }
            return null;
        }

        public void SetNoItemText(string text)
        {
            noItemsText = text;
        }

        public IListAdapter GetAdapter(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return piece;
                position -= size;
            }
            return null;
        }
    }

}


