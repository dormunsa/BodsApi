// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!                                                !!
// !! The following code is automatically generated. !!
// !!                                                !!
// !!            DO NOT EDIT THIS CODE               !!
// !!                                                !!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace bods
{

    public static class bods
    {



        public static string ConnectionString;
        public static Camera Tcamera = new Camera();
        public static Detection Tdetection = new Detection();
        public static User Tuser = new User();
        public static Usercamera Tusercamera = new Usercamera();
        public static Weather Tweather = new Weather();
        public class Camera
        {


            public static implicit operator string(Camera table_name)
            { return "camera"; }



            public string Cn
            {
                get { return "bods.camera"; }
            }

            // camera fields



            public CameraId FCameraId = new CameraId();

            public LocationName FLocationName = new LocationName();

            public Longitude FLongitude = new Longitude();

            public Latitude FLatitude = new Latitude();

            public IsWorking FIsWorking = new IsWorking();

            public DateAdded FDateAdded = new DateAdded();

            public class CameraId
            {

                public static implicit operator string(CameraId field_name)
                {
                    return "camera.CameraId";
                }

                public string Cn
                {
                    get { return "bods.camera.CameraId"; }
                }

                public string OnlyColumnName
                {
                    get { return "CameraId"; }
                }
            }

            public class LocationName
            {

                public static implicit operator string(LocationName field_name)
                {
                    return "camera.LocationName";
                }

                public string Cn
                {
                    get { return "bods.camera.LocationName"; }
                }

                public string OnlyColumnName
                {
                    get { return "LocationName"; }
                }
            }

            public class Longitude
            {

                public static implicit operator string(Longitude field_name)
                {
                    return "camera.Longitude";
                }

                public string Cn
                {
                    get { return "bods.camera.Longitude"; }
                }

                public string OnlyColumnName
                {
                    get { return "Longitude"; }
                }
            }

            public class Latitude
            {

                public static implicit operator string(Latitude field_name)
                {
                    return "camera.Latitude";
                }

                public string Cn
                {
                    get { return "bods.camera.Latitude"; }
                }

                public string OnlyColumnName
                {
                    get { return "Latitude"; }
                }
            }

            public class IsWorking
            {

                public static implicit operator string(IsWorking field_name)
                {
                    return "camera.IsWorking";
                }

                public string Cn
                {
                    get { return "bods.camera.IsWorking"; }
                }

                public string OnlyColumnName
                {
                    get { return "IsWorking"; }
                }
            }

            public class DateAdded
            {

                public static implicit operator string(DateAdded field_name)
                {
                    return "camera.DateAdded";
                }

                public string Cn
                {
                    get { return "bods.camera.DateAdded"; }
                }

                public string OnlyColumnName
                {
                    get { return "DateAdded"; }
                }
            }

            // camera indexes



            public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

            public class IndexPRIMARY
            {

                public static implicit operator string(IndexPRIMARY index_name)
                {
                    return "PRIMARY";
                }
            }
        }
        public class Detection
        {


            public static implicit operator string(Detection table_name)
            { return "detection"; }



            public string Cn
            {
                get { return "bods.detection"; }
            }

            // detection fields



            public DetectionId FDetectionId = new DetectionId();

            public CameraId FCameraId = new CameraId();

            public ImagePath FImagePath = new ImagePath();

            public WeatherId FWeatherId = new WeatherId();

            public Date FDate = new Date();

            public class DetectionId
            {

                public static implicit operator string(DetectionId field_name)
                {
                    return "detection.DetectionId";
                }

                public string Cn
                {
                    get { return "bods.detection.DetectionId"; }
                }

                public string OnlyColumnName
                {
                    get { return "DetectionId"; }
                }
            }

            public class CameraId
            {

                public static implicit operator string(CameraId field_name)
                {
                    return "detection.CameraId";
                }

                public string Cn
                {
                    get { return "bods.detection.CameraId"; }
                }

                public string OnlyColumnName
                {
                    get { return "CameraId"; }
                }
            }

            public class ImagePath
            {

                public static implicit operator string(ImagePath field_name)
                {
                    return "detection.ImagePath";
                }

                public string Cn
                {
                    get { return "bods.detection.ImagePath"; }
                }

                public string OnlyColumnName
                {
                    get { return "ImagePath"; }
                }
            }

            public class WeatherId
            {

                public static implicit operator string(WeatherId field_name)
                {
                    return "detection.WeatherId";
                }

                public string Cn
                {
                    get { return "bods.detection.WeatherId"; }
                }

                public string OnlyColumnName
                {
                    get { return "WeatherId"; }
                }
            }

            public class Date
            {

                public static implicit operator string(Date field_name)
                {
                    return "detection.Date";
                }

                public string Cn
                {
                    get { return "bods.detection.Date"; }
                }

                public string OnlyColumnName
                {
                    get { return "Date"; }
                }
            }

            // detection indexes



            public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

            public class IndexPRIMARY
            {

                public static implicit operator string(IndexPRIMARY index_name)
                {
                    return "PRIMARY";
                }
            }
        }
        public class User
        {


            public static implicit operator string(User table_name)
            { return "user"; }



            public string Cn
            {
                get { return "bods.user"; }
            }

            // user fields



            public UserId FUserId = new UserId();

            public UserName FUserName = new UserName();

            public SaltPassword FSaltPassword = new SaltPassword();

            public IsAdmin FIsAdmin = new IsAdmin();

            public FirstName FFirstName = new FirstName();

            public LastName FLastName = new LastName();

            public AdminId FAdminId = new AdminId();

            public CreationDate FCreationDate = new CreationDate();

            public HashedPassword FHashedPassword = new HashedPassword();

            public IsSetPasswordAllowed FIsSetPasswordAllowed = new IsSetPasswordAllowed();

            public UserGuid FUserGuid = new UserGuid();

            public Phone FPhone = new Phone();

            public SlackWebHook FSlackWebHook = new SlackWebHook();

            public class UserId
            {

                public static implicit operator string(UserId field_name)
                {
                    return "user.UserId";
                }

                public string Cn
                {
                    get { return "bods.user.UserId"; }
                }

                public string OnlyColumnName
                {
                    get { return "UserId"; }
                }
            }

            public class UserName
            {

                public static implicit operator string(UserName field_name)
                {
                    return "user.UserName";
                }

                public string Cn
                {
                    get { return "bods.user.UserName"; }
                }

                public string OnlyColumnName
                {
                    get { return "UserName"; }
                }
            }

            public class SaltPassword
            {

                public static implicit operator string(SaltPassword field_name)
                {
                    return "user.SaltPassword";
                }

                public string Cn
                {
                    get { return "bods.user.SaltPassword"; }
                }

                public string OnlyColumnName
                {
                    get { return "SaltPassword"; }
                }
            }

            public class IsAdmin
            {

                public static implicit operator string(IsAdmin field_name)
                {
                    return "user.IsAdmin";
                }

                public string Cn
                {
                    get { return "bods.user.IsAdmin"; }
                }

                public string OnlyColumnName
                {
                    get { return "IsAdmin"; }
                }
            }

            public class FirstName
            {

                public static implicit operator string(FirstName field_name)
                {
                    return "user.FirstName";
                }

                public string Cn
                {
                    get { return "bods.user.FirstName"; }
                }

                public string OnlyColumnName
                {
                    get { return "FirstName"; }
                }
            }

            public class LastName
            {

                public static implicit operator string(LastName field_name)
                {
                    return "user.LastName";
                }

                public string Cn
                {
                    get { return "bods.user.LastName"; }
                }

                public string OnlyColumnName
                {
                    get { return "LastName"; }
                }
            }

            public class AdminId
            {

                public static implicit operator string(AdminId field_name)
                {
                    return "user.AdminId";
                }

                public string Cn
                {
                    get { return "bods.user.AdminId"; }
                }

                public string OnlyColumnName
                {
                    get { return "AdminId"; }
                }
            }

            public class CreationDate
            {

                public static implicit operator string(CreationDate field_name)
                {
                    return "user.CreationDate";
                }

                public string Cn
                {
                    get { return "bods.user.CreationDate"; }
                }

                public string OnlyColumnName
                {
                    get { return "CreationDate"; }
                }
            }

            public class HashedPassword
            {

                public static implicit operator string(HashedPassword field_name)
                {
                    return "user.HashedPassword";
                }

                public string Cn
                {
                    get { return "bods.user.HashedPassword"; }
                }

                public string OnlyColumnName
                {
                    get { return "HashedPassword"; }
                }
            }

            public class IsSetPasswordAllowed
            {

                public static implicit operator string(IsSetPasswordAllowed field_name)
                {
                    return "user.IsSetPasswordAllowed";
                }

                public string Cn
                {
                    get { return "bods.user.IsSetPasswordAllowed"; }
                }

                public string OnlyColumnName
                {
                    get { return "IsSetPasswordAllowed"; }
                }
            }

            public class UserGuid
            {

                public static implicit operator string(UserGuid field_name)
                {
                    return "user.UserGuid";
                }

                public string Cn
                {
                    get { return "bods.user.UserGuid"; }
                }

                public string OnlyColumnName
                {
                    get { return "UserGuid"; }
                }
            }

            public class Phone
            {

                public static implicit operator string(Phone field_name)
                {
                    return "user.Phone";
                }

                public string Cn
                {
                    get { return "bods.user.Phone"; }
                }

                public string OnlyColumnName
                {
                    get { return "Phone"; }
                }
            }

            public class SlackWebHook
            {

                public static implicit operator string(SlackWebHook field_name)
                {
                    return "user.SlackWebHook";
                }

                public string Cn
                {
                    get { return "bods.user.SlackWebHook"; }
                }

                public string OnlyColumnName
                {
                    get { return "SlackWebHook"; }
                }
            }

            // user indexes



            public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

            public class IndexPRIMARY
            {

                public static implicit operator string(IndexPRIMARY index_name)
                {
                    return "PRIMARY";
                }
            }
        }
        public class Usercamera
        {


            public static implicit operator string(Usercamera table_name)
            { return "usercamera"; }



            public string Cn
            {
                get { return "bods.usercamera"; }
            }

            // usercamera fields



            public UserId FUserId = new UserId();

            public CameraId FCameraId = new CameraId();

            public class UserId
            {

                public static implicit operator string(UserId field_name)
                {
                    return "usercamera.UserId";
                }

                public string Cn
                {
                    get { return "bods.usercamera.UserId"; }
                }

                public string OnlyColumnName
                {
                    get { return "UserId"; }
                }
            }

            public class CameraId
            {

                public static implicit operator string(CameraId field_name)
                {
                    return "usercamera.CameraId";
                }

                public string Cn
                {
                    get { return "bods.usercamera.CameraId"; }
                }

                public string OnlyColumnName
                {
                    get { return "CameraId"; }
                }
            }

            // usercamera indexes



            public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

            public class IndexPRIMARY
            {

                public static implicit operator string(IndexPRIMARY index_name)
                {
                    return "PRIMARY";
                }
            }
        }
        public class Weather
        {


            public static implicit operator string(Weather table_name)
            { return "weather"; }



            public string Cn
            {
                get { return "bods.weather"; }
            }

            // weather fields



            public WeatherId FWeatherId = new WeatherId();

            public LocationName FLocationName = new LocationName();

            public Longitude FLongitude = new Longitude();

            public Latitude FLatitude = new Latitude();

            public Date FDate = new Date();

            public WindSpeed FWindSpeed = new WindSpeed();

            public Description FDescription = new Description();

            public class WeatherId
            {

                public static implicit operator string(WeatherId field_name)
                {
                    return "weather.WeatherId";
                }

                public string Cn
                {
                    get { return "bods.weather.WeatherId"; }
                }

                public string OnlyColumnName
                {
                    get { return "WeatherId"; }
                }
            }

            public class LocationName
            {

                public static implicit operator string(LocationName field_name)
                {
                    return "weather.LocationName";
                }

                public string Cn
                {
                    get { return "bods.weather.LocationName"; }
                }

                public string OnlyColumnName
                {
                    get { return "LocationName"; }
                }
            }

            public class Longitude
            {

                public static implicit operator string(Longitude field_name)
                {
                    return "weather.Longitude";
                }

                public string Cn
                {
                    get { return "bods.weather.Longitude"; }
                }

                public string OnlyColumnName
                {
                    get { return "Longitude"; }
                }
            }

            public class Latitude
            {

                public static implicit operator string(Latitude field_name)
                {
                    return "weather.Latitude";
                }

                public string Cn
                {
                    get { return "bods.weather.Latitude"; }
                }

                public string OnlyColumnName
                {
                    get { return "Latitude"; }
                }
            }

            public class Date
            {

                public static implicit operator string(Date field_name)
                {
                    return "weather.Date";
                }

                public string Cn
                {
                    get { return "bods.weather.Date"; }
                }

                public string OnlyColumnName
                {
                    get { return "Date"; }
                }
            }

            public class WindSpeed
            {

                public static implicit operator string(WindSpeed field_name)
                {
                    return "weather.WindSpeed";
                }

                public string Cn
                {
                    get { return "bods.weather.WindSpeed"; }
                }

                public string OnlyColumnName
                {
                    get { return "WindSpeed"; }
                }
            }

            public class Description
            {

                public static implicit operator string(Description field_name)
                {
                    return "weather.Description";
                }

                public string Cn
                {
                    get { return "bods.weather.Description"; }
                }

                public string OnlyColumnName
                {
                    get { return "Description"; }
                }
            }

            // weather indexes



            public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

            public class IndexPRIMARY
            {

                public static implicit operator string(IndexPRIMARY index_name)
                {
                    return "PRIMARY";
                }
            }
        }
    } // end of class 

} // namespace bods



// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!                                                !!
// !!       End of automatically generated code      !!
// !!                                                !!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


