using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWEF_1_Ado.net_
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ContextStore())
            {
                #region AddItems
                //Console.WriteLine("Сколько товаров добавить?");
                //int countStore = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countStore; i++)
                //{
                //    Console.WriteLine("Введите наименование товара?");
                //    string nameItems = Console.ReadLine();
                //    Console.WriteLine("Введите кол-во товара?");
                //    int countItems = int.Parse(Console.ReadLine());
                //    Console.WriteLine("Введите цену товара?");
                //    int priceItems = int.Parse(Console.ReadLine());

                //    var store = new Storage
                //    {
                //        NameItems = nameItems,
                //        CountItems = countItems,
                //        PriceItems = priceItems
                //    };
                //    context.Stores.Add(store);
                //}
                //context.SaveChanges();
                #endregion

                #region Change&DeleteItems
                Console.WriteLine("Выберите действие \n1-Изменить\n2-Удалить");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    #region Change
                    case 1:
                        Console.WriteLine("Выберите колонку которую хотите изменить");
                        Console.WriteLine("1-Name");
                        Console.WriteLine("2-Price");
                        Console.WriteLine("3-Count");
                        int choiceColumn = int.Parse(Console.ReadLine());

                        if (choiceColumn == 1)
                        {
                            Console.WriteLine("Введите название товара, которого хотите изменить?");
                            string nameStore = Console.ReadLine();

                            var getId = (from item in context.Stores
                                         where item.NameItems.Contains(nameStore)
                                         select item).FirstOrDefault();

                            if (getId != null)
                            {
                                Console.WriteLine("Введите название товара на какое хотите изменить?");
                                string nameStoreChange = Console.ReadLine();
                                getId.NameItems = nameStoreChange;
                                context.SaveChanges();
                            }
                        }

                        else if (choiceColumn == 2)
                        {
                            Console.WriteLine("Введите название товара, цену которого хотите изменить?");
                            string nameStore = Console.ReadLine();
                            var getId = (from item in context.Stores
                                         where item.NameItems.Contains(nameStore)
                                         select item).FirstOrDefault();

                            if (getId != null)
                            {
                                Console.WriteLine("Введите цену этого товара вместо предыдущей цены?");
                                int price = int.Parse(Console.ReadLine());
                                getId.PriceItems = price;
                                context.SaveChanges();
                            }
                        }
                        else if (choiceColumn == 3)
                        {
                            Console.WriteLine("Введите название товара, кол-во которого хотите изменить?");
                            string nameStore = Console.ReadLine();
                            var getId = (from item in context.Stores
                                         where item.NameItems.Contains(nameStore)
                                         select item).FirstOrDefault();

                            if (getId != null)
                            {
                                Console.WriteLine("Введите кол-во товара вместо предыдущего кол-ва?");
                                int count = int.Parse(Console.ReadLine());
                                getId.CountItems = count;
                                context.SaveChanges();
                            }
                        }
                        break;
                    #endregion
                    #region Delete
                    case 2:
                            Console.WriteLine("Введите название товара, которого хотите удалить?");
                            string nameStoreDel = Console.ReadLine();
                            var getIdDel = (from item in context.Stores
                                         where item.NameItems.Contains(nameStoreDel)
                                         select item).FirstOrDefault();

                            if (getIdDel != null)
                            {
                                context.Stores.Remove(getIdDel);
                                context.SaveChanges();
                            }
                        break;
                        #endregion
                }
                #endregion
            }

        }
    }
}
