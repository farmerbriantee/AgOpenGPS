using System;
using System.Collections.Generic;

namespace RateController
{
    public class clsProducts
    {
        public IList<clsProduct> Items; // access records by index
        private List<clsProduct> cProducts = new List<clsProduct>();
        private DateTime LastSave;
        private int MaxRecords = 5;
        private FormStart mf;

        public clsProducts(FormStart CallingForm)
        {
            mf = CallingForm;
            Items = cProducts.AsReadOnly();
        }

        public int Count()
        {
            return cProducts.Count;
        }

        public clsProduct Item(int ProdID)  // access records by Product ID
        {
            int IDX = ListID(ProdID);
            if (IDX == -1) throw new IndexOutOfRangeException();
            return cProducts[IDX];
        }

        public void Load()
        {
            cProducts.Clear();
            for (int i = 0; i < MaxRecords; i++)
            {
                clsProduct Prod = new clsProduct(mf, i);
                cProducts.Add(Prod);
                Prod.Load();
            }
        }

        public void Save(int ProdID = 0)
        {
            if (ProdID == 0)
            {
                // save all
                for (int i = 0; i < MaxRecords; i++)
                {
                    cProducts[i].Save();
                }
            }
            else
            {
                // save selected
                cProducts[ListID(ProdID)].Save();
            }
        }

        public bool UniqueModSen(int ModID, int SenID, int ProdID)
        {
            // checks if product module ID/sensor ID pair are unique
            bool Result = true;
            for (int i = 0; i < Count(); i++)
            {
                if (cProducts[i].ID != ProdID)  // exclude current product
                {
                    if (cProducts[i].ModuleID == ModID & cProducts[i].SensorID == SenID)
                    {
                        Result = false;
                        break;
                    }
                }
            }
            return Result;
        }

        public void Update()
        {
            for (int i = 0; i < MaxRecords; i++)
            {
                cProducts[i].Update();
            }

            if ((DateTime.Now - LastSave).TotalSeconds > 60)
            {
                for (int i = 0; i < MaxRecords; i++)
                {
                    cProducts[i].Save();
                }
                LastSave = DateTime.Now;
            }
        }

        public void UpdateVirtualNano()
        {
            for (int i = 0; i < MaxRecords; i++)
            {
                if (cProducts[i].SimulationType == SimType.VirtualNano) cProducts[i].VirtualNano.MainLoop();
            }
        }

        private int ListID(int ProdID)
        {
            for (int i = 0; i < cProducts.Count; i++)
            {
                if (cProducts[i].ID == ProdID) return i;
            }
            return -1;
        }
    }
}