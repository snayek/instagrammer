﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class PhotosController : BaseController {
        public PhotosController() : base() { }

        //
        // GET: /Photos/
        public ActionResult Index() {
            try {
                UsersController controller = new UsersController(base.userToken.access_token);
                ApiResponse<UserFeed> media = controller.RecentMedia(null, null, null);

                ViewData["PreviousPage"] = "";
                ViewData["Photos"] = media;
            } catch { }
            return View();
        }

        public ActionResult Next() {
            string next_max_id = RouteData.Values["id"] != null ? RouteData.Values["id"].ToString() : "";
            UsersController controller = new UsersController(base.userToken.access_token);
            ApiResponse<UserFeed> media = controller.RecentMedia(null, next_max_id, null);

            ViewData["PreviousPage"] = media.data[0].id;
            ViewData["Photos"] = media;

            return View("Index");
        }

        public ActionResult Previous() {
            string prev_max_id = RouteData.Values["id"] != null ? RouteData.Values["id"].ToString() : "";
            UsersController controller = new UsersController(base.userToken.access_token);
            ApiResponse<UserFeed> media = controller.RecentMedia(null, null, prev_max_id);

            ViewData["PreviousPage"] = media.data[0].id;
            ViewData["Photos"] = media;

            return View("Index");
        }

        public ActionResult Details() {
            object mediaId;
            RouteData.Values.TryGetValue("id", out mediaId);
            
            try {
                MediaController mediaController = new MediaController(userToken.access_token);
                ViewData["PhotoDetails"] = mediaController.Media(mediaId.ToString()).data;

            } catch (System.Net.WebException ex) {
                ViewData["Error"] = ex.Message;
            }

            return View();
        }
    }
}