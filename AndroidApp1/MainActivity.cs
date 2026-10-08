using Android.App;
using Android.OS;
using Android.Widget;
using System.Net.Http.Json;
using System.Net.Http.Json;
namespace AndroidApp1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]

    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            var x = new HttpClient();
            int idmiz = 0;
            string arabaAdi = "";
            string port = "5183";
            string ip = "http://10.46.121.26:";

            Verim verim = new Verim();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            TextView yazi = FindViewById<TextView>(Resource.Id.yaziAlani)!;
            Button buton = FindViewById<Button>(Resource.Id.tiklaButon)!;
            Button buton2 = FindViewById<Button>(Resource.Id.tiklaButon2)!;

            EditText intid = FindViewById<EditText>(Resource.Id.iddeger)!;
            EditText stringid = FindViewById<EditText>(Resource.Id.stringdeger)!;



            buton.Click += async (sender, e) =>
            {
                var ListOfCars = await x.GetFromJsonAsync<List<Car>>(ip + port + "/ListOfCars");
                yazi.Text =$"Favori araba listesi:\n1. Araba:{ListOfCars[0].ArabaAdi}\n2. Araba:{ListOfCars[1].ArabaAdi}\n3. Araba:{ListOfCars[2].ArabaAdi}";
            };
            buton2.Click += async (sender, e) =>
            {
                arabaAdi = stringid.Text;
                idmiz = int.Parse(intid.Text);
                verim.AArabaAdi = arabaAdi;
                verim.Id = idmiz;
                await x.PostAsJsonAsync<Verim>(ip + port + "/ListOfCars/arabaAdi", verim);
                var ListOfCars = await x.GetFromJsonAsync<List<Car>>(ip + port + "/ListOfCars");

                yazi.Text = $"Favori araba listesi:\n1. Araba:{ListOfCars[0].ArabaAdi}\n2. Araba:{ListOfCars[1].ArabaAdi}\n3. Araba:{ListOfCars[2].ArabaAdi}";

            };
        }
    }
}
public class Car
{
    public string ArabaAdi { get; set; }
    public Car() { }
    public Car(string ArabaAdi)
    {
        this.ArabaAdi = ArabaAdi;
    }

}
public class Verim
{
    public string AArabaAdi { get; set; }
    public int Id { get; set; }
}