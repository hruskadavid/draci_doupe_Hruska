using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dracak_wpf_Hruska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool pom = false;
        int cast = 0;
        int uroven = 0;
        int postava = 0;
        List<Monstrum> Monstra = new List<Monstrum>();
        List<Hrac> hraci = new List<Hrac>();
        List<Weapon> Zbrane = new List<Weapon>();

        public object NavigationService { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            //vytvoření základních Monster
            Monstra.Add(new Monstrum() { Jmeno = "Monstrum", Utok = 1, Zivoty = 30 });
            Monstra.Add(new Monstrum() { Jmeno = "Monstrum", Utok = 2, Zivoty = 35 });
            Monstra.Add(new Monstrum() { Jmeno = "Monstrum", Utok = 3, Zivoty = 37 });
            Monstra.Add(new Monstrum() { Jmeno = "Monstrum", Utok = 4, Zivoty = 40 });
            Monstra.Add(new Monstrum() { Jmeno = "Monstrum", Utok = 5, Zivoty = 45 });

            //IVENTAR + ZBRANE (další zbraně budou postupně vytvořeny + se budou moci dát získat postupem příběhu
            Zbrane.Add(new Weapon() { Jmeno_zbrane = "Meč a štít", Body = 5, Zivoty = 10 });
            Zbrane.Add(new Weapon() { Jmeno_zbrane = "Dva meče", Body = 10 , Zivoty = 5});

            //vytvoření základních postav
            hraci.Add(new Hrac() { Jmeno = "Elf", Utok = 10, Zivoty = 0, Body = 20 });
            hraci.Add(new Hrac() { Jmeno = "Assassin", Utok = 5, Zivoty = 10, Body = 20 });
            //Základní grafika je zobrazena, postupen času se různě zobrazují jiné další obrázky, které souvisí s daným příběhem + se ukazuje obrázek daného charakteru
            monster_gif.Opacity = 0;
            hero_gif.Opacity = 0;
            warrior_gif.Opacity = 0;
            netopyr_gif.Opacity = 0;
            water_gif.Opacity = 0;
            town_jpg.Opacity = 0;
            village_jpg.Opacity = 0;
            bandita_gif.Opacity = 0;
            grizzly_gif.Opacity = 0;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button4.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
            button8.Visibility = Visibility.Visible;
            button9.Visibility = Visibility.Visible;
            body2.Visibility = Visibility.Hidden;
            zivoty2.Visibility = Visibility.Hidden;
            utok2.Visibility = Visibility.Hidden;
            HP.Visibility = Visibility.Hidden;

            text.Text = ("Vítej, vyber si postavu");


        }
        //Tlačítka na výběr ze dvou postav
        public void Elf(object sender, EventArgs args)
        {
            hraci[0].Zbran = Zbrane[0].Jmeno_zbrane;
            hraci[0].Utok = hraci[0].Utok + Zbrane[0].Body;
            hraci[0].Zivoty = hraci[0].Zivoty + Zbrane[0].Zivoty;
            inventar.Content = Zbrane[0].Jmeno_zbrane;
            postava = 0;
            pribeh();
        }
        public void Assassin(object sender, EventArgs args)
        {
            hraci[1].Zbran = Zbrane[1].Jmeno_zbrane;
            hraci[1].Utok = hraci[1].Utok + Zbrane[1].Body;
            hraci[1].Zivoty = hraci[1].Zivoty + Zbrane[1].Zivoty;
            inventar.Content = Zbrane[1].Jmeno_zbrane;
            postava = 1;
            pribeh();
        }
        //tlačítko na přidávání životů jako atributů
        public void plus_zivot(object sender, EventArgs args)
        {
            if (hraci[postava].Body > 0)
            {

                hraci[postava].Zivoty = hraci[postava].Zivoty + 1;
            hraci[postava].Body = hraci[postava].Body - 1;
            body.Content = (hraci[postava].Body);
            zivoty.Content = (hraci[postava].Zivoty);
            }
            

        }
        //tlačítko na ubírání životů jako atributů(nelze se dostat do záporných čísel)
        public void minus_zivot(object sender, EventArgs args)
        {

            if (hraci[postava].Zivoty > 0)
            {
                hraci[postava].Zivoty = hraci[postava].Zivoty - 1;
            hraci[postava].Body = hraci[postava].Body + 1;
            body.Content = (hraci[postava].Body);
            zivoty.Content = (hraci[postava].Zivoty);
            }
            

        }
        //tlačítko na přidávání útoku jako atributů
        public void plus_utok(object sender, EventArgs args)
        {

            if (hraci[postava].Body > 0)
            {
                hraci[postava].Utok = hraci[postava].Utok + 1;
            hraci[postava].Body = hraci[postava].Body - 1;
            body.Content = (hraci[postava].Body);
            utok.Content = (hraci[postava].Utok);
            }
          

        }
        //tlačítko na ubírání útoku jako atributů(nelze se dostat do záporných čísel)
        public void minus_utok(object sender, EventArgs args)
        {

            if (hraci[postava].Utok > 0) {
                hraci[postava].Utok = hraci[postava].Utok - 1;
            hraci[postava].Body = hraci[postava].Body + 1;
            body.Content = (hraci[postava].Body);
            utok.Content = (hraci[postava].Utok);
            }
           

        }
        //tlačítko ne, pro odmítání různych ukolů
        public void ne(object sender, EventArgs args)
        {
            pom = false;
            body.Content = (hraci[postava].Body);
            
                pribeh();
            
        }
        //tlačítko ano, pro postup v příběhu + pro přijmání úkolů
        public void ano(object sender, EventArgs args)
        {


            pom = true;
            body.Content = (hraci[postava].Body);
        
            pribeh();
            
        }
        //základní tlačítko na útok, nic složitého, ale připraveno na velký počet monster a velký počet postav, tak aby se tato funkce nemusela měnit,
        //pokud útok skončí příběh jde dál a nebo skončí smrtí postavy
        public void zautocit(object sender, EventArgs args)
        {

            
            zivoty.Content = (hraci[postava].Zivoty);
            utok.Content = (hraci[postava].Utok);
            body.Content = (hraci[postava].Body);
            HP.Value =   Monstra[uroven].Zivoty;
            Monstra[uroven].Zivoty = Monstra[uroven].Zivoty - hraci[postava].Utok;
            hraci[postava].Zivoty = hraci[postava].Zivoty - Monstra[uroven].Utok;
            if (Monstra[uroven].Zivoty < 1)
            {
                
                cast = cast + 1;
                hraci[postava].Body = hraci[postava].Body + 5;
                button6.Visibility = Visibility.Visible;
                button7.Visibility = Visibility.Visible;
                button5.Visibility = Visibility.Hidden;
                HP.Visibility = Visibility.Hidden;
                text.Text = ("Porazil jsi Monstrum chceš jít dál?");
            }
            if (hraci[postava].Zivoty < 1)
            {
                prohra();
            }

        }

        public void pribeh()
        {
            //hlavní část hry, 7 částí hry, které jdou vždy stejně za sebou, během hry se hráčovi vypisuje vše ohledně jeho charakteru a příběhu,
            //následně je u každého levelu jiný obrázek, který souvisí s daným levelem, za každý level dostane hráč body a za každé odmítnutí hrát naopak body zdtrácí
            //Monstra získávají každým kolem větší sílu
            switch (cast)
            {
                case 0:
                    if (postava == 0)
                    {
                        hero_gif.Opacity = 100;
                        
                    } else {
                        warrior_gif.Opacity = 100;
                    }
                    text.Text = ("Jsi na malém pahorku v ranních hodinách a vidíš v dálce městečko kam se máš dostat, jsi připraven na cestu?");
                    pom = false;
                    cast = cast + 1;
                    pribeh();
                    zivoty.Content = (hraci[postava].Zivoty);
                    utok.Content = (hraci[postava].Utok);
                    body.Content = (hraci[postava].Body);
                    button1.Visibility = Visibility.Visible;
                    button2.Visibility = Visibility.Visible;
                    button3.Visibility = Visibility.Visible;
                    button4.Visibility = Visibility.Visible;
                    button5.Visibility = Visibility.Hidden;
                    button8.Visibility = Visibility.Hidden;
                    button9.Visibility = Visibility.Hidden;
                    body2.Visibility = Visibility.Visible;
                    zivoty2.Visibility = Visibility.Visible;
                    utok2.Visibility = Visibility.Visible;
                    village_jpg.Opacity = 100;
                    hero2_gif.Opacity = 0;
                    warrior2_gif.Opacity = 0;
                    HP.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {
                        text.Text = ("V malém lese, který si potkal hned na začátku jsi potkal první monstrum,poraž ho!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        monster_gif.Opacity = 100;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 0;
                        water_gif.Opacity = 0;
                        town_jpg.Opacity = 0;
                        village_jpg.Opacity = 0;
                        bandita_gif.Opacity = 0;
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Visible;
                        HP.Visibility = Visibility.Visible;
                        HP.Value = Monstra[0].Zivoty;
                        HP.Maximum = 30;

                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                    break;
                case 2:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {
                        uroven = uroven + 1;
                        monster_gif.Opacity = 0;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 0;
                        water_gif.Opacity = 100;
                        town_jpg.Opacity = 0;
                        bandita_gif.Opacity = 0;
                        text.Text = ("Po prvním monstru jsi došel k řece kde na tebe čeká první vodní monstrum, poraž ho!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        HP.Value = Monstra[1].Zivoty;
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Visible;
                        HP.Visibility = Visibility.Visible;
                        HP.Maximum = 35;
                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                break;
                case 3:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {
                        uroven = uroven + 1;
                        text.Text = ("o přeprodění řeky jsi se dostal k jeskyni plné netopýrů, poraž je!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        monster_gif.Opacity = 0;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 100;
                        water_gif.Opacity = 0;
                        town_jpg.Opacity = 0;
                        bandita_gif.Opacity = 0;
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Visible;
                        HP.Visibility = Visibility.Visible;
                        HP.Value = Monstra[2].Zivoty;
                        HP.Maximum = 37;
                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                    break;
                case 4:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {
                        uroven = uroven + 1;
                        text.Text = ("Po tom co jsi prolezl jeskyni jsi spatřil nebezpečného banditu, který se tě snaží zabít, poraž ho!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        monster_gif.Opacity = 0;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 0;
                        water_gif.Opacity = 0;
                        town_jpg.Opacity = 0;
                        bandita_gif.Opacity = 100;
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Visible;
                        HP.Visibility = Visibility.Visible;
                        HP.Value = Monstra[3].Zivoty;
                        HP.Maximum = 40;
                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                    break;
                case 5:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {
                        uroven = uroven + 1;
                        text.Text = ("Po tom co jsi porazil nebezpečného banditu, ti v cestě stojí velký medvěd s obrovskými drápy, který se tě snaží za každou cenu zabít, poraž ho!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        monster_gif.Opacity = 0;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 0;
                        water_gif.Opacity = 0;
                        town_jpg.Opacity = 0;
                        grizzly_gif.Opacity = 100;
                        bandita_gif.Opacity = 0;
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Visible;
                        HP.Visibility = Visibility.Visible;
                        HP.Value = Monstra[4].Zivoty;
                        HP.Maximum = 45;
                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                    break;
                case 6:
                    if (pom == false)
                    {
                        cast = cast + 0;
                        hraci[postava].Body = hraci[postava].Body - 1;
                    }
                    else
                    {

                        monster_gif.Opacity = 0;
                        if (postava == 0)
                        {
                            hero_gif.Opacity = 100;

                        }
                        else
                        {
                            warrior_gif.Opacity = 100;
                        }
                        netopyr_gif.Opacity = 0;
                        water_gif.Opacity = 0;
                        town_jpg.Opacity = 100;
                        grizzly_gif.Opacity = 0;
                        button1.Visibility = Visibility.Hidden;
                        button2.Visibility = Visibility.Hidden;
                        button3.Visibility = Visibility.Hidden;
                        button4.Visibility = Visibility.Hidden;
                        button5.Visibility = Visibility.Hidden;
                        button6.Visibility = Visibility.Hidden;
                        button7.Visibility = Visibility.Hidden;
                        HP.Visibility = Visibility.Hidden;
                        text.Text = ("Po tom co jsi porazil velkého medvěda, jsi uviděl krásné město nedaleko odsud, ve městě si našel princeznu do, které si se hned zamiloval, gratuluji k výhře!");
                        zivoty.Content = (hraci[postava].Zivoty);
                        utok.Content = (hraci[postava].Utok);
                        body.Content = (hraci[postava].Body);
                        body2.Visibility = Visibility.Hidden;
                        zivoty2.Visibility = Visibility.Hidden;
                        utok2.Visibility = Visibility.Hidden;
                        body.Visibility = Visibility.Hidden;
                        zivoty.Visibility = Visibility.Hidden;
                        utok.Visibility = Visibility.Hidden;
                        if (hraci[postava].Zivoty < 1)
                        {
                            prohra();
                        }
                    }
                    break;
                default:
                    cast = 0;
                    break;
            }
        }
        //2 růžné možnosti konce hry

            //ukončení prosté, aplikace se jen zavře, dále bych chtěl upravit aby byla možnost začít i novou hru
        public void vypnout(object sender, EventArgs args)
        {
           
            Application.Current.Shutdown();


        }
        //Funkce na prohru, celé grafika zmizí, hráč je vyzván na ukončení aplikace
        public void prohra()
        {
            
            text.Text = ("Prohrál jsi, prosím zavři hru v pravém horním rohu");
            monster_gif.Opacity = 0;
            if (postava == 0)
            {
                hero_gif.Opacity = 100;

            }
            else
            {
                warrior_gif.Opacity = 100;
            }
            netopyr_gif.Opacity = 0;
            water_gif.Opacity = 0;
            town_jpg.Opacity = 0;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button4.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
            button6.Visibility = Visibility.Hidden;
            button7.Visibility = Visibility.Hidden;
            HP.Visibility = Visibility.Hidden;
            zivoty.Content = (hraci[postava].Zivoty);
            utok.Content = (hraci[postava].Utok);
            body.Content = (hraci[postava].Body);


        }

    }
}
