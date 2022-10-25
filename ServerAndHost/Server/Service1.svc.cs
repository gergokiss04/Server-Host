using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    public class Service1 : IService1
    {
        public static List<Szedvics> SzendvicsekListaja = new List<Szedvics>();
        public static HashSet<int> SzendvicsekIndex=new HashSet<int>();

        int Pozicio(int id)
        {
            for (int i = 0; i < SzendvicsekListaja.Count; i++)
            {
                if (SzendvicsekListaja[i].Id==id)
                {
                    return i;
                }
                
            }
            return -1;
        }
        public string EgySzendvicsPostCS(Szedvics szedvics)
        {
            if (szedvics !=null)
            {
                int id =(int)szedvics.Id;
                if (!SzendvicsekIndex.Contains(id))
                {
                    SzendvicsekListaja.Add(szedvics);
                    SzendvicsekIndex.Add(id);
                    return "Adatok tárolása sikeresen megtörtént!";
                }
                else
                {
                    return "Már van ilyen azonosítóval szendvics!";
                }
            }
            else
            {
                return "Null értéket kaptam a body-ban!";
            }
        }

        public string EgySzendvicsPost(Szedvics szedvics)
        {
            return EgySzendvicsPostCS(szedvics);
        }

        public string EgySzendvicsPutCS(Szedvics szedvics)
        {
            if (szedvics != null)
            {
                int id = (int)szedvics.Id;
                if (!SzendvicsekIndex.Contains(id))
                {
                    return "Nincs ilyen id-vel rendelkező szendvics!";
                }
                else
                {
                    SzendvicsekListaja[Pozicio(id)] = szedvics;
                    return "Adatok módosítása sikeresen megtörtént!";
                }
            }
            else
            {
                return "Null értéket kaptam a body-ban!";
            }
        }

        public string EgySzendvicsPut(Szedvics szedvics)
        {
            return EgySzendvicsPutCS(szedvics);
        }

        public string EgySzendvicsDeleteCS(int id)
        {
            if (id != null)
            {
               
                if (!SzendvicsekIndex.Contains(id))
                {
                    return "Nincs ilyen id-vel rendelkező szendvics!";
                }
                else
                {
                    SzendvicsekListaja.RemoveAt(Pozicio(id));  
                    SzendvicsekIndex.Remove(id);
                    return "Adatok törlése sikeresen megtörtént!";
                }
            }
            else
            {
                return "Null értéket kaptam a body-ban!";
            }
        }

        public string EgySzendvicsDelete(int id)
        {
            return EgySzendvicsDeleteCS(id);
        }


        public Szedvics EgySzendvicsGetCS()
        {
            Szedvics egySzendvics=new Szedvics();
            egySzendvics.Id = 1;
            egySzendvics.PekaruTipusa = "Zsemle";
            egySzendvics.Vaj = "Rama margarin";
            egySzendvics.SzalamiKarikakSzama = 0;
            egySzendvics.HusFeltet = "párizsi";
            egySzendvics.Szalveta = false;
            egySzendvics.ZoldsegFeltet = "paradicsom";
            return egySzendvics;
        }

        public Szedvics EgySzendvicsGet()
        {
            return EgySzendvicsGetCS();
        }
    }
}
