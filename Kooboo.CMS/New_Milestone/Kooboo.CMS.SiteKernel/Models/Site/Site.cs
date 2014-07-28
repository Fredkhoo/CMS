﻿#region License
// 
// Copyright (c) 2013, Kooboo team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using Kooboo.CMS.Common;
using Kooboo.CMS.Common.Persistence.Non_Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Kooboo.CMS.SiteKernel.Models
{
    public partial class Site : IIdentifiable
    {
        #region Current
        public static Site Current
        {
            get
            {
                return ContextVariables.Current.GetObject<Site>("Current_Site");
            }
            set
            {
                ContextVariables.Current.SetObject("Current_Site", value);
            }
        }
        #endregion

        public string UUID
        {
            get
            {
                return this.FullName;
            }
            set
            {
                // null setter
            }
        }
    }
    public partial class Site
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Culture { get; set; }
        public string Theme { get; set; }

        public ReleaseMode Mode { get; set; }

        public bool Published { get; set; }

        public string Version { get; set; }

        public Smtp Smtp { get; set; }

        /// <summary>
        /// 1  站点的设置加了一个时区设置
        /// 2. 在添加内容的时候，所有的时间都认为是这个时区的时间
        /// 3. 在存储到数据库的时候，自动把时间转换成UTC世界
        /// 4. 在查询和独取得时候，会自动把UTC 时间转换成站点设置的时区时间 
        /// 5. 开发人员的代码中，需要保存的时间和使用的时间，都是假设站点时区的时间
        /// 6. 遇到像生日之类的，与时区无关的时间，开发人员可以设计用datetimepicker控件，但是存储的时候使用string存储。避免具有时间的时区性。
        /// </summary>
        /// <value>
        /// The time zone id.
        /// </value>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// 全局性的HtmlMeta设置
        /// </summary>
        public HtmlMeta HtmlMeta { get; set; }

        public Dictionary<string, string> CustomFields { get; set; }

        // Repository,Membership，还有以后可能的其它模块，是不是反方向设置会比较容易扩展？
        public string Repository { get; set; }
        public string Membership { get; set; }

        /// <summary>
        /// 可能不需要，用插件形式扩展引用JQuery
        /// </summary>
        public bool EnableJQuery { get; set; }
        /// <summary>
        /// 可能不需要，做成插件扩展会更好
        /// </summary>
        public bool EnableInlineEditing { get; set; }
        public bool EnableVersioning { get; set; }
        public bool EnableStyleEditing { get; set; }

        ///用扩展实现
        //KeyValue<string, string> SSLDetection { get; set; }


    }
}