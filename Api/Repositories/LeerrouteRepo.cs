//using KeuzeWijzerApi.DAL.DataEntities;
//using KeuzeWijzerApi.Repositories.Interfaces;

//namespace KeuzeWijzerApi.Repositories
//{
//    public class LeerrouteRepo : ILeerrouteRepo
//    {
//        private static readonly List<LearningRoute> leerroutes = new()
//        {
//            //new LeerrouteDto {
//            //    Id = 1,
//            //    Name = "Route1",
//            //    Modules = new List<ModuleDto>()
//            //    {
//            //        new ModuleDto { id = 1, description = "", name = "" },
//            //        new ModuleDto { id = 2, description = "", name = "" }
//            //    }
//            //},
//            //new LeerrouteDto {
//            //    Id = 2,
//            //    Name = "Route2",
//            //    Modules = new List<ModuleDto>()
//            //    {
//            //        new ModuleDto { id = 3, description = "", name = "" },
//            //        new ModuleDto { id = 4, description = "", name = "" }
//            //    }
//            //}
//        };

//        /// <summary>
//        /// Ugly Temp Leerroute to return when id is not found
//        /// </summary>
//        private LearningRoute tempNotFound = new()
//        {
//            //Id = 999,
//            //Name = "NotFound",
//            //Modules = new List<ModuleDto>()
//            //    {
//            //        new ModuleDto { id = 777, description = "NotFound", name = "NotFound" },
//            //        new ModuleDto { id = 888, description = "NotFound", name = "NotFound" }
//            //    }
//        };

//        public LeerrouteRepo()
//        {
//        }

//        public LearningRoute DeleteLeerroute(int Id)
//        {
//            var toDel = GetLeerroute(Id);

//            if (toDel != null)
//            {
//                leerroutes.Remove(toDel);
//                return toDel;
//            }

//            return tempNotFound;

//        }

//        public List<LearningRoute> GetAllLeerroute()
//        {
//            return leerroutes;
//        }

//        public LearningRoute GetLeerroute(int Id)
//        {
//            LearningRoute? leerroute = leerroutes.FirstOrDefault(x => x.Id == Id);

//            if (leerroute != null)
//            {
//                leerroutes.Remove(leerroute);
//                return leerroute;
//            }

//            return tempNotFound;
//        }

//        public void SaveLeerroute(LearningRoute leerroute)
//        {
//            leerroutes.Add(leerroute);
//        }
//    }
//}
