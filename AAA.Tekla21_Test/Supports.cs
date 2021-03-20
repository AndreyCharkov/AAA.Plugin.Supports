using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using Tekla.Structures;
using System.Collections;
using Tekla.Structures.Geometry3d;

namespace AAA.Plugin.Supports
{
    public class Supports
    {
        public void TR31(int A, int B, int C, int _steel,string _profile, int X1, int Y1, int Z1, int X2, int Y2, int Z2) //Входные данные Размеры A B C, Материал, Профиль, Позиция 1(XYZ), Позиция 2 (XYZ)
        {
            ProfileTransformation profile = new ProfileTransformation();
            CustomPart Support = new CustomPart();
            TypeSteel steel = new TypeSteel();
            Support.Name = "TR31";//Имя компонента
            Support.Number = BaseComponent.CUSTOM_OBJECT_NUMBER; // Базоввый номер компонента
            Support.Position.Plane = Position.PlaneEnum.MIDDLE; // На плоскости-Середина
            Support.Position.PlaneOffset = 0;
            Support.Position.Depth = Position.DepthEnum.FRONT;//Высота - Спереду
            Support.Position.DepthOffset = 0;
            Support.Position.Rotation = Position.RotationEnum.TOP;//Поворот - Сверху
            Support.Position.RotationOffset = 0;
            Support.SetInputPositions(new Point(X1, Y1, Z1), new Point(X2, Y2, Z2)); //Позиция x y z точка 1 и точка 2
            Support.SetAttribute("A", A); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("B", B); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("C", C); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("profile", profile.Angle(_profile)); //Заполнение атрибутов (имя артибута, значение), переопределение профиля из таблицы
            Support.SetAttribute("material", steel.Steel(_steel)); //Заполнение атрибутов (имя артибута, значение), переопределение стали из таблицы
            Support.Insert(); // Вставка компонента
        }
        public void TR34(int A, int B, int C, int _steel, string _profile, int X1, int Y1, int Z1, int X2, int Y2, int Z2) //Входные данные Размеры A B C, Материал, Профиль, Позиция 1(XYZ), Позиция 2 (XYZ)
        {
            ProfileTransformation profile = new ProfileTransformation();
            CustomPart Support = new CustomPart();
            TypeSteel steel = new TypeSteel();
            Support.Name = "TR34";//Имя компонента
            Support.Number = BaseComponent.CUSTOM_OBJECT_NUMBER; // Базоввый номер компонента
            Support.Position.Plane = Position.PlaneEnum.MIDDLE; // На плоскости-Середина
            Support.Position.PlaneOffset = 0;
            Support.Position.Depth = Position.DepthEnum.FRONT;//Высота - Спереду
            Support.Position.DepthOffset = 0;
            Support.Position.Rotation = Position.RotationEnum.TOP;//Поворот - Сверху
            Support.Position.RotationOffset = 0;
            Support.SetInputPositions(new Point(X1, Y1, Z1), new Point(X2, Y2, Z2)); //Позиция x y z точка 1 и точка 2
            Support.SetAttribute("A", A); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("B", B); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("C", C); //Заполнение атрибутов (имя артибута, значение)
            Support.SetAttribute("profile", profile.Angle(_profile)); //Заполнение атрибутов (имя артибута, значение), переопределение профиля из таблицы
            Support.SetAttribute("material", steel.Steel(_steel)); //Заполнение атрибутов (имя артибута, значение), переопределение стали из таблицы
            Support.Insert(); // Вставка компонента
        }
    }
}
