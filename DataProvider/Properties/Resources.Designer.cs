﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataProvider.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DataProvider.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [dbo].[AddDeliveryJob] 
        ///   @CustomerName
        ///  ,@SaleDate
        ///  ,@PreferedDate
        ///  ,@Phone
        ///  ,@DeliveryAddress
        ///  ,@attachmentName
        ///  ,@input_type
        ///  ,@Remarks
        ///  ,@username
        ///  ,@lines
        ///  ,@RECEIPTID_OUT OUTPUT
        ///  ,@HEADER_ID OUTPUT.
        /// </summary>
        internal static string ADD_DELIVERY {
            get {
                return ResourceManager.GetString("ADD_DELIVERY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [delivery_log_1] ( HEADER_ID ,
        ///                               DETAILS_ID ,
        ///                               LOG_DATE ,
        ///                               STATUS ,
        ///                               REMARKS ,
        ///                               STATUS_DATE ,
        ///                               USER_NAME
        ///                             )
        ///VALUES ( @header_id ,
        ///         @details_id ,
        ///         GETDATE() ,
        ///         @status ,
        ///         @remark ,
        ///         GETDATE() ,
        ///         @user_name
        ///       ).
        /// </summary>
        internal static string CMD_UPDATE_LOG {
            get {
                return ResourceManager.GetString("CMD_UPDATE_LOG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT HEADER_ID AS                          &quot;HeaderId&quot; ,
        ///       ISNULL(RECEIPTID , LPO_NUMBER) AS     &quot;Receipt&quot; ,
        ///       ORA_ORDER_NO AS                       &quot;OrderNumber&quot; ,
        ///       NAME AS                               &quot;CustomerName&quot; ,
        ///       TRANSDATE AS                          &quot;SaleDate&quot; ,
        ///       PHONE AS                              &quot;Phone&quot; ,
        ///       ISNULL(DELIVERY_ADDRESS , ADDRESS) AS &quot;DeliveryAddress&quot; ,
        ///       INT_STATUS AS                         &quot;Status&quot; ,
        ///       DT_SCHEDULED AS           [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DELIVERY_HEADER {
            get {
                return ResourceManager.GetString("DELIVERY_HEADER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT id AS           &quot;LineId&quot; ,
        ///       TRANSDATE AS    &quot;SaleDate&quot; ,
        ///       LINENUM AS      &quot;LineNumber&quot; ,
        ///       ITEMID AS       &quot;ItemCode&quot; ,
        ///       DESCRIPTION AS  &quot;Description&quot; ,
        ///       QUANTITY AS     &quot;OrderQuantity&quot; ,
        ///       ISNULL(SEIINGPRICE ,0) AS  &quot;SelleingPrice&quot; ,
        ///       INT_STATUS AS   &quot;Status&quot; ,
        ///       DT_SCHEDULED AS &quot;ScheduledDate&quot; ,
        ///       TIME_SLOT AS    &quot;TimeSlot&quot; ,
        ///       DRIVER_NAME AS  &quot;DriverName&quot; ,
        ///       VEHICLE_CODE AS &quot;VehicleCode&quot; ,
        ///       GPS AS          &quot;GPS&quot; ,
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DELIVERY_LINES {
            get {
                return ResourceManager.GetString("DELIVERY_LINES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT ISNULL(h.ORA_ORDER_NO , h.RECEIPTID) AS &quot;OrderNumber&quot; ,
        ///       l.TRANSDATE AS                          &quot;TransDate&quot; ,
        ///       DT_DELIVERED AS                         &quot;DeliveredDate&quot; ,
        ///       STATUS_DESC AS                          &quot;StatusDesc&quot; ,
        ///       lo.REMARKS AS                           &quot;Remark&quot;
        ///FROM delivery_header AS h INNER JOIN delivery_details AS l ON h.HEADER_ID = l.HEADER_ID
        ///                          INNER JOIN delivery_status_1 AS s ON l.INT_STATUS = s.STATUS_CODE
        ///                   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GET_DELIVERY_STATUS_VIEW {
            get {
                return ResourceManager.GetString("GET_DELIVERY_STATUS_VIEW", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT HEADER_ID AS                      &quot;HeaderId&quot; ,
        ///       ISNULL(RECEIPTID , LPO_NUMBER) AS &quot;Receipt&quot; ,
        ///       NAME AS                           &quot;CustomerName&quot; ,
        ///       h.INT_STATUS AS               &quot;Status&quot;
        ///FROM delivery_header AS h LEFT JOIN delivery_status_1 AS stat ON h.INT_STATUS = stat.STATUS_CODE
        ///inner join delivery_users u on u.[USER_ID] = h.EMP_ID
        ///WHERE u.[USER_NAME] = @USER_NAME
        ///      AND
        ///      TRANS_TYPE = @TRANSTYPE
        ///ORDER BY HEADER_ID DESC.
        /// </summary>
        internal static string MOBILE_ORDER {
            get {
                return ResourceManager.GetString("MOBILE_ORDER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT id AS           &quot;LineId&quot; ,
        ///       TRANSDATE AS    &quot;SaleDate&quot; ,
        ///       LINENUM AS      &quot;LineNumber&quot; ,
        ///       ITEMID AS       &quot;ItemCode&quot; ,
        ///       DESCRIPTION AS  &quot;Description&quot; ,
        ///       QUANTITY AS     &quot;OrderQuantity&quot; ,
        ///       ISNULL(SEIINGPRICE ,0) AS  &quot;SelleingPrice&quot; ,
        ///       INT_STATUS AS   &quot;Status&quot; ,
        ///       DT_SCHEDULED AS &quot;ScheduledDate&quot; ,
        ///       TIME_SLOT AS    &quot;TimeSlot&quot; ,
        ///       DRIVER_NAME AS  &quot;DriverName&quot; ,
        ///       VEHICLE_CODE AS &quot;VehicleCode&quot; ,
        ///       GPS AS          &quot;GPS&quot; ,
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MOBILE_ORDER_DETAIL {
            get {
                return ResourceManager.GetString("MOBILE_ORDER_DETAIL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE delivery_scheduled
        ///       SET
        ///           INT_STATUS = @INT_STATUS ,
        ///           REMARKS = @REMARKS ,
        ///           DT_ESTIMATED = @DT_ESTIMATED ,
        ///           DT_STATUS = GETDATE() ,
        ///           DT_DELIVERED = CASE @INT_STATUS
        ///                              WHEN 11
        ///                              THEN GETDATE()
        ///                              ELSE DT_DELIVERED
        ///                          END
        ///WHERE id = @id.
        /// </summary>
        internal static string UPDATE_DELIVER_LINE {
            get {
                return ResourceManager.GetString("UPDATE_DELIVER_LINE", resourceCulture);
            }
        }
    }
}