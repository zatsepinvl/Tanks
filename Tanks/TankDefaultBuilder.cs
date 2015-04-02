using System;
using System.Drawing;
using System.Text;

namespace Tanks
{
    public class TankDefaultBuilder:IBuilder<Tank>
    {
        public const int enginePower = 300;
        public const int engineWeight = 200;
        public const int engineVolume = 8;
        public const int towerAtack = 30;
        public const int towerDefense = 20;
        public const int towerWeight = 500;
        public const int bodyDefense = 40;
        public const int bodyWeight = 2000;
        public const int tankHealth = 100;
        public const int tankSpeed = 5;
        public static Color bodyColor = Color.DarkGreen;
        public static Color towerColor = Color.Green;
        public static Color barrelColor = Color.Black;
        public static SizeF bodySize = new SizeF(40, 60);
        public static SizeF towerSize = new SizeF(30, 30);
        public static SizeF barrelSize = new SizeF(10, 30);
        public static PointF tankDefaultLocation = new PointF(200, 200);
        public void Build(Tank arg)
        {
            arg.Body = GetDefaultBody();
            arg.Engine = GetDefaultEngine();
            arg.Tower = GetDefaultTower();
            arg.SetLocation(tankDefaultLocation.X, tankDefaultLocation.Y);
            arg.Health = tankHealth;
            arg.Speed = tankSpeed;
            arg.TurnUp();
        }
        public static Body GetDefaultBody()
        {
            Body b = new Body();
            b.Defense = bodyDefense;
            b.Weight = bodyWeight;
            b.Color = bodyColor;
            b.SetSize(bodySize);
            return b;
        }
        public static Tower GetDefaultTower()
        {
            Tower t = new Tower();
            t.Atack = towerAtack;
            t.Defense = towerDefense;
            t.Weight = towerWeight;
            t.Color = towerColor;
            t.SetSize(towerSize);
            t.Barrel.Color = barrelColor;
            t.Barrel.SetSize(barrelSize);
            return t;
        }
        public static Engine GetDefaultEngine()
        {
            Engine e = new Engine();
            e.Power = enginePower;
            e.Weight = engineWeight;
            e.Volume = engineVolume;
            return e;
        }
    }
}
