using System.ComponentModel.DataAnnotations;

/// <summary>
/// Enum eSPermission
/// </summary>
public enum eSPermission
    : int
{
    /// <summary>
    /// The none
    /// </summary>
    NONE = 1,

    /// <summary>
    /// The parent menues
    /// </summary>
    PARENT_MENUES,
    /// <summary>
    /// The menu dashbord view
    /// </summary>
    MENU_DASHBORD_VIEW,
    /// <summary>
    /// The menu request view
    /// </summary>
    MENU_REQUEST_VIEW,
    /// <summary>
    /// The menu request list view
    /// </summary>
    MENU_REQUEST_LIST_VIEW,
    /// <summary>
    /// The menu request insert view
    /// </summary>
    MENU_REQUEST_INSERT_VIEW,
    /// <summary>
    /// The menu sale view
    /// </summary>
    MENU_SALE_VIEW,
    /// <summary>
    /// The menu sale prefactor view
    /// </summary>
    MENU_SALE_PREFACTOR_VIEW,
    /// <summary>
    /// The menu sale factor view
    /// </summary>
    MENU_SALE_FACTOR_VIEW,
    /// <summary>
    /// The menu financial view
    /// </summary>
    MENU_FINANCIAL_VIEW,
    /// <summary>
    /// The menu purchase view
    /// </summary>
    MENU_Purchase_VIEW,
    /// <summary>
    /// The menu buy request view
    /// </summary>
    MENU_BuyRequest_VIEW,
    /// <summary>
    /// The menu buy purchase contract view
    /// </summary>
    MENU_BuyPurchaseContract_VIEW,
    /// <summary>
    /// The menu buy announcing need view
    /// </summary>
    MENU_BuyAnnouncingNeed_VIEW,
    /// <summary>
    /// The menu warehouse view
    /// </summary>
    MENU_Warehouse_VIEW,
    /// <summary>
    /// The menu warehouse activity view
    /// </summary>
    MENU_Warehouse_ACTIVITY_VIEW,
    /// <summary>
    /// The menu warehouse activity cartech view
    /// </summary>
    MENU_Warehouse_ACTIVITY_CARTECH_VIEW,
    /// <summary>
    /// The menu warehouse activity receipt view
    /// </summary>
    MENU_Warehouse_ACTIVITY_RECEIPT_VIEW,
    /// <summary>
    /// The menu warehouse activity document view
    /// </summary>
    MENU_Warehouse_ACTIVITY_DOCUMENT_VIEW,
    /// <summary>
    /// The menu warehouse activity handling view
    /// </summary>
    MENU_Warehouse_ACTIVITY_HANDLING_VIEW,
    /// <summary>
    /// The menu warehouse activity firstcourse view
    /// </summary>
    MENU_Warehouse_ACTIVITY_FIRSTCOURSE_VIEW,
    /// <summary>
    /// The menu warehouse list view
    /// </summary>
    MENU_Warehouse_LIST_VIEW,
    /// <summary>
    /// The menu warehouse listthing view
    /// </summary>
    MENU_Warehouse_LISTTHING_VIEW,
    /// <summary>
    /// The menu warehouse insert view
    /// </summary>
    MENU_Warehouse_INSERT_VIEW,
    /// <summary>
    /// The menu thing view
    /// </summary>
    MENU_THING_VIEW,
    /// <summary>
    /// The menu thing list view
    /// </summary>
    MENU_THING_LIST_VIEW,
    /// <summary>
    /// The menu thing insertbook view
    /// </summary>
    MENU_THING_INSERTBOOK_VIEW,
    /// <summary>
    /// The menu thing insertcommodityview
    /// </summary>
    MENU_THING_INSERTCOMMODITYVIEW,
    /// <summary>
    /// The menu basicinformation view
    /// </summary>
    MENU_BASICINFORMATION_VIEW,
    /// <summary>
    /// The menu basicinformation warehouse view
    /// </summary>
    MENU_BASICINFORMATION_Warehouse_VIEW,
    /// <summary>
    /// The menu basicinformation thing view
    /// </summary>
    MENU_BASICINFORMATION_THING_VIEW,
    /// <summary>
    /// The menu basicinformation thingbook view
    /// </summary>
    MENU_BASICINFORMATION_THINGBOOK_VIEW,
    /// <summary>
    /// The menu basicinformation interfaces view
    /// </summary>
    MENU_BASICINFORMATION_INTERFACES_VIEW,
    /// <summary>
    /// The menu basicinformation user view
    /// </summary>
    MENU_BASICINFORMATION_USER_VIEW,
    /// <summary>
    /// The menu it view
    /// </summary>
    MENU_IT_VIEW,
    /// <summary>
    /// The menu businesscouncil view
    /// </summary>
    MENU_BUSINESSCOUNCIL_VIEW,
    /// <summary>
    /// The menu generaltrading view
    /// </summary>
    MENU_GENERALTRADING_VIEW,
    /// <summary>
    /// The menu subscribe view
    /// </summary>
    MENU_SUBSCRIBE_VIEW,
    /// <summary>
    /// The menu musers view
    /// </summary>
    MENU_MUSERS_VIEW,
    /// <summary>
    /// The menu musers list view
    /// </summary>
    MENU_MUSERS_LIST_VIEW,
    /// <summary>
    /// The menu musers access view
    /// </summary>
    MENU_MUSERS_ACCESS_VIEW,
    /// <summary>
    /// The menu musers insert view
    /// </summary>
    MENU_MUSERS_INSERT_VIEW,
    /// <summary>
    /// The parent request
    /// </summary>
    PARENT_REQUEST,
    /// <summary>
    /// The view information shop
    /// </summary>
    VIEW_INFO_SHOP,

    /// <summary>
    /// The parent work
    /// </summary>
    PARENT_WORK,
    /// <summary>
    /// The work shop
    /// </summary>
    WORK_SHOP,
    /// <summary>
    /// The work interface
    /// </summary>
    WORK_INTERFACE,
    /// <summary>
    /// The work language hangout
    /// </summary>
    WORK_LANGUAGE_HANGOUT,
    /// <summary>
    /// The work sales department
    /// </summary>
    WORK_SALES_DEPARTMENT,
    /// <summary>
    /// The work purchase department
    /// </summary>
    WORK_PURCHASE_DEPARTMENT,
    /// <summary>
    /// The work commerce department
    /// </summary>
    WORK_COMMERCE_DEPARTMENT,
    /// <summary>
    /// The work warehouse department
    /// </summary>
    WORK_Warehouse_DEPARTMENT,
    /// <summary>
    /// مالی
    /// </summary>
    WORK_FINANCIAL,
    /// <summary>
    /// The guest public
    /// </summary>
    GUEST_PUBLIC,
}
