namespace Bustop.Hanlders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Web.Script.Serialization;
    using System.Web.SessionState;
    using System.Collections;
    using System.IO;
    using CargoManagementSystem;
    using System.Net;
    using System.Globalization;
    using System.Threading;


    /// <summary>
    /// Summary description for Bus
    /// </summary>
    public class Bus : IHttpHandler, IRequiresSessionState
    {
        string username = "";

        public bool IsReusable
        {
            get { return true; }
        }

        public class vehiclesclass
        {
            public string vehicleno { get; set; }
            public string vehicletype { get; set; }
        }

        public class Groupsclass
        {
            public string groupname { get; set; }
            public List<string> vehicleno { get; set; }
        }
        class orderdetail
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RtnQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }

        }
        class Inventorydetail
        {
            public string SNo { set; get; }
            public string InvSno { set; get; }
            public string GivenQty { set; get; }
            public string ReceivedQty { set; get; }
            public string BalanceQty { set; get; }
            public string TransQty { set; get; }
        }
        class InvDatails
        {
            public string SNo { set; get; }
            public string Qty { set; get; }
            public string TripID { set; get; }
        }
        class Leakagedetail
        {
            public string SNo { set; get; }
            public string ProductID { set; get; }
            public string LeakageQty { set; get; }
            public string DeductionAmount { set; get; }
        }
        class RouteLeakdetails
        {
            public string SNo { set; get; }
            public string ProductID { set; get; }
            public string LeaksQty { set; get; }
            public string ReturnsQty { set; get; }
            public string TripID { set; get; }
        }
        class Orders
        {
            public string op { set; get; }
            public string BranchID { set; get; }
            public List<orderdetail> data { set; get; }
            public List<orderdetail> offerdata { set; get; }
            public List<Inventorydetail> Inventorydetails { set; get; }
            public List<Leakagedetail> Leakagedetails { set; get; }
            public List<RouteLeakdetails> RouteLeakdetails { set; get; }
            public List<InvDatails> InvDatails { set; get; }
            public string totqty { set; get; }
            public string totrate { set; get; }
            public string totTotal { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string TotalPrice { set; get; }
            public string BalanceAmount { set; get; }
            public string PaidAmount { set; get; }
            public string TotalCost { set; get; }
            public string Remarks { set; get; }
            public string PaymentType { set; get; }
            public string Denominations { set; get; }
            public string ColAmount { set; get; }
            public string SubAmount { set; get; }
            public string IndentType { set; get; }
            public string EmpName { set; get; }
            public string RouteId { set; get; }
            public string SaveType { set; get; }
            public string DispDate { set; get; }
            public string Mode { set; get; }
            public string DispSno { set; get; }
        }
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string operation = context.Request["op"];
                switch (operation)
                {
                    case "getBranchValues":
                        getBranchValues(context);
                        break;
                    case "getofferBranchValues":
                        getofferBranchValues(context);
                        break;
                    case "getFinalDC":
                        getFinalDC(context);
                        break;
                    case "getBranchValuesamount":
                        getBranchValuesamount(context);
                        break;
                    case "getTodayDate":
                        getTodayDate(context);
                        break;
                    case "GetInventoryNames":
                        GetInventoryNames(context);
                        break;
                    case "GetProductNamechange":
                        GetProductNamechange(context);
                        break;
                    case "GetDeliverInventory":
                        GetDeliverInventory(context);
                        break;
                    case "getBranchLeakeges":
                        getBranchLeakeges(context);
                        break;
                    case "FillCategeoryname":
                        FillCategeoryname(context);
                        break;
                    case "get_product_subcategory_data":
                        get_product_subcategory_data(context);
                        break;
                    case "get_products_data":
                        get_products_data(context);
                        break;
                    case "AddBranchProducts":
                        AddBranchProducts(context);
                        break;
                    case "GetInvReport":
                        GetInvReport(context);
                        break;
                    case "getReportAmount":
                        getReportAmount(context);
                        break;
                    case "GetRouteNameChange":
                        GetRouteNameChange(context);
                        break;
                    case "CollectionReports":
                        CollectionReports(context);
                        break;
                    case "GetProductIndent":
                        GetProductIndent(context);
                        break;
                    case "GetIndentStatus":
                        GetIndentStatus(context);
                        break;
                    case "GetDispatchAgents":
                        GetDispatchAgents(context);
                        break;
                    case "GetDispatchBranch":
                        GetDispatchBranch(context);
                        break;
                    case "GetIndentType":
                        GetIndentType(context);
                        break;
                    case "GetCsodispatchRoutes":
                        GetCsodispatchRoutes(context);
                        break;
                    case "GetSOEmployeeNames":
                        GetSOEmployeeNames(context);
                        break;
                    case "GetDispProducts":
                        GetDispProducts(context);
                        break;
                    case "GetShortageProducts":
                        GetShortageProducts(context);
                        break;
                    case "GetCollectionStatus":                
                        GetCollectionStatus(context);
                        break;
                    case "GetDispInventory":
                        GetDispInventory(context);
                        break;
                    case "GetTripNo":
                        GetTripNo(context);
                        break;
                    case "getOrderStatus":
                        getOrderStatus(context);
                        break;
                    case "GetVerifyInventory":
                        GetVerifyInventory(context);
                        break;
                    case "DeliverReportclick":
                        DeliverReportclick(context);
                        break;
                    case "GetReturnLeakReport":
                        GetReturnLeakReport(context);
                        break;
                    case "GetVerifyLeaks":
                        GetVerifyLeaks(context);
                        break;
                    case "GetVerifyReturns":
                        GetVerifyReturns(context);
                        break;
                    case "ValidateLogin":
                        ValidateLogin(context);
                        break;
                    case "changepassword":
                        changepassword(context);
                        break;
                    case "GetPermissions":
                        GetPermissions(context);
                        break;
                    case "IndentReportSaveclick":
                        IndentReportSaveclick(context);
                        break;
                    case "GetDisTypeChange":
                        GetDisTypeChange(context);
                        break;
                    case "GetDispname":
                        GetDispname(context);
                        break;
                    case "GetRouteEmployeeNames":
                        GetRouteEmployeeNames(context);
                        break;
                    case "DispatchReportClick":
                        DispatchReportClick(context);
                        break;
                    case "GetSODispatchClick":
                        GetSODispatchClick(context);
                        break;
                    case "GetPlantDispatchProducts":
                        GetPlantDispatchProducts(context);
                        break;
                    case "GetPlantDispatchInventory":
                        GetPlantDispatchInventory(context);
                        break;
                    case "SoSalesOFFIceProducts":
                        SoSalesOFFIceProducts(context);
                        break;
                    case "SoSalesOFFIceInventory":
                        SoSalesOFFIceInventory(context);
                        break;
                    case "GetSOPlantDispatches":
                        GetSOPlantDispatches(context);
                        break;
                    ////////........Agent Sale.........//////////
                    case "GetAgentProducts":
                        GetAgentProducts(context);
                        break;
                    case "GetDirectAgentProducts":
                        GetDirectAgentProducts(context);
                        break;
                    case "GetAgentInventory":
                        GetAgentInventory(context);
                        break;
                    case "GetSalesOfficeLeaks":
                        GetSalesOfficeLeaks(context);
                        break;
                    case "GetSoRoutes":
                        GetSoRoutes(context);
                        break;
                    case "GetOrderReport":
                        GetOrderReport(context);
                        break;
                    case "GetProductReport":
                        GetProductReport(context);
                        break;
                    case "CollectionSaveClick":
                        CollectionSaveClick(context);
                        break;
                        
                    default:
                        var js = new JavaScriptSerializer();
                        var title1 = context.Request.Params[1];
                        Orders obj = js.Deserialize<Orders>(title1);
                        if (obj.op == "btnOrderSaveClick")
                        {
                            btnOrderSaveClick(context);
                        }
                        if (obj.op == "btnDeliversSaveClick")
                        {
                            btnDeliversSaveClick(context);
                        }
                        if (obj.op == "btnFinalDCSaveClick")
                        {
                            btnFinalDCSaveClick(context);
                        }
                        //if (obj.op == "CollectionSaveClick")
                        //{
                        //    CollectionSaveClick(context);
                        //}
                        if (obj.op == "btnRemarksSaveClick")
                        {
                            btnRemarksSaveClick(context);
                        }
                        if (obj.op == "btnDispatchSaveClick")
                        {
                            btnDispatchSaveClick(context);
                        }
                        if (obj.op == "btnShoratageSaveClick")
                        {
                            btnShoratageSaveClick(context);
                        }
                        if (obj.op == "btnReportingInventoryclick")
                        {
                            btnReportingInventoryclick(context);
                        }
                        if (obj.op == "btnInventoryVerifySaveClick")
                        {
                            btnInventoryVerifySaveClick(context);
                        }
                        if (obj.op == "btnLeakVarifySaveClick")
                        {
                            btnLeakVarifySaveClick(context);
                        }
                        if (obj.op == "btnReturnsVarifySaveClick")
                        {
                            btnReturnsVarifySaveClick(context);
                        }
                        if (obj.op == "btnSOProductTransferSaveClick")
                        {
                            btnSOProductTransferSaveClick(context);
                        }
                        if (obj.op == "btnAgentProductSaveClick")
                        {
                            btnAgentProductSaveClick(context);
                        }
                        if (obj.op == "btnAgentColInventorySaveClick")
                        {
                            btnAgentColInventorySaveClick(context);
                        }
                        if (obj.op == "btnSalesofficeLeakSaveClick")
                        {
                            btnSalesofficeLeakSaveClick(context);
                        }
                        if (obj.op == "btnDirectAgentProductSaveClick")
                        {
                            btnDirectAgentProductSaveClick(context);
                        }

                        break;
                }
            }
            catch
            {
            }
        }

        private void GetProductReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteID = "";
                string IndentType = context.Request["IndentType"];
                if (IndentType == "")
                {
                    IndentType = context.Session["IndentType"].ToString();
                }
                string Count = context.Session["count"].ToString();
                if (Count == "1")
                {
                    RouteID = context.Session["RouteId"].ToString();
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, productsdata.ProductName,ROUND(Sum(indents_subtable.unitQty),2) as unitQty  FROM branchdata INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (branchroutesubtable.RefNo = @RouteID) AND (indents.I_date BETWEEN @d1 AND @d2) AND (indents.IndentType = @IndentType) GROUP BY  productsdata.ProductName");
                }
                else
                {
                    RouteID = context.Session["RouteId"].ToString();
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, productsdata.ProductName, ROUND(Sum(indents_subtable.unitQty),2) as unitQty, dispatch_sub.dispatch_sno FROM branchdata INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutesubtable.RefNo = dispatch_sub.Route_id WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents.IndentType = @IndentType) AND (dispatch_sub.dispatch_sno = @RouteID) GROUP BY  productsdata.ProductName, dispatch_sub.dispatch_sno");

                }

                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@RouteID", RouteID);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                List<IndentClass> Indentlist = new List<IndentClass>();
                if (dtIndentData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtIndentData.Rows)
                    {
                        IndentClass GetIndent = new IndentClass();
                        GetIndent.unitQty = dr["unitQty"].ToString();
                        GetIndent.ProductName = dr["ProductName"].ToString();
                        Indentlist.Add(GetIndent);
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetOrderReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteID = "";
                string IndentType = context.Request["IndentType"];
                if (IndentType == "")
                {
                    IndentType = context.Session["IndentType"].ToString();
                }
                string Count = context.Session["count"].ToString();
                if (Count == "1")
                {
                    RouteID = context.Session["RouteId"].ToString();
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, productsdata.ProductName, indents_subtable.unitQty FROM branchdata INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (branchroutesubtable.RefNo = @RouteID) AND (indents.I_date BETWEEN @d1 AND @d2) AND (indents.IndentType = @IndentType) GROUP BY branchdata.BranchName, productsdata.ProductName");
                }
                else
                {
                    RouteID = context.Session["RouteId"].ToString();
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, productsdata.ProductName, indents_subtable.unitQty, dispatch_sub.dispatch_sno FROM branchdata INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutesubtable.RefNo = dispatch_sub.Route_id WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents.IndentType = @IndentType) AND (dispatch_sub.dispatch_sno = @RouteID) GROUP BY branchdata.BranchName, productsdata.ProductName, dispatch_sub.dispatch_sno");

                }
               
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@RouteID", RouteID);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                List<IndentClass> Indentlist = new List<IndentClass>();
                if (dtIndentData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtIndentData.Rows)
                    {
                        IndentClass GetIndent = new IndentClass();
                        GetIndent.BranchName = dr["BranchName"].ToString();
                        GetIndent.unitQty = dr["unitQty"].ToString();
                        GetIndent.ProductName = dr["ProductName"].ToString();
                        Indentlist.Add(GetIndent);
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class IndentClass
        {
            public string BranchName { get; set; }
            public string unitQty { get; set; }
            public string ProductName { get; set; }
        }
        private void GetSoRoutes(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string branchid = context.Session["CsoNo"].ToString();
                cmd = new MySqlCommand("SELECT Sno, RouteName FROM branchroutes WHERE (BranchID = @BranchID)");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                DataTable dtRoute = vdm.SelectQuery(cmd).Tables[0];
                List<Route> Routelist = new List<Route>();
                foreach (DataRow dr in dtRoute.Rows)
                {
                    Route b = new Route() { rid = dr["Sno"].ToString(), RouteName = dr["RouteName"].ToString() };
                    Routelist.Add(b);
                }
                string response = GetJson(Routelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void btnSalesofficeLeakSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                 vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);

                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            double BranchQty = 0;
                            double.TryParse(o.Qty, out BranchQty);
                            BranchQty = Math.Round(BranchQty,2);
                            double LeakQty = 0;
                            double.TryParse(o.LeakQty, out LeakQty);
                            LeakQty = Math.Round(LeakQty, 2);
                            double ShortQty = 0;
                            double.TryParse(o.ShortQty, out ShortQty);
                            ShortQty = Math.Round(ShortQty, 2);
                            double FreeQty = 0;
                            double.TryParse(o.FreeMilk, out FreeQty);
                            FreeQty = Math.Round(FreeQty, 2);
                            cmd = new MySqlCommand("Update branchProducts Set BranchQty=@BranchQty,LeakQty=LeakQty+@LeakQty where branch_sno=@BranchId and Product_sno=@ProductId");
                            cmd.Parameters.Add("@BranchQty", BranchQty);
                            cmd.Parameters.Add("@LeakQty", LeakQty);
                            cmd.Parameters.Add("@FreeQty", FreeQty);
                            cmd.Parameters.Add("@ShortQty", ShortQty);
                            cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                            cmd.Parameters.Add("@ProductId", o.Productsno);
                            vdm.Update(cmd);
                            cmd = new MySqlCommand("insert into branchleaktrans (prodid,LeakQty,EmpId,TripId,DOE,BranchId,FreeQty,ShortQty) values(@prodid,@LeakQty,@EmpId,@TripId,@DOE,@BranchId,@FreeQty,@ShortQty)");
                            cmd.Parameters.Add("@prodid", o.Productsno);
                            cmd.Parameters.Add("@LeakQty", LeakQty);
                            cmd.Parameters.Add("@FreeQty", FreeQty);
                            cmd.Parameters.Add("@ShortQty", ShortQty);
                            cmd.Parameters.Add("@EmpId", context.Session["PlantEmpId"].ToString());
                            cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                            vdm.insert(cmd);
                        }
                    }
                    string Msg = "Saved Successfully";
                    string response = GetJson(Msg);
                    context.Response.Write(response);
                }
            }
            catch(Exception ex)
            {
                string Msg = ex.Message;
                string response = GetJson(Msg);
                context.Response.Write(response);
            }
        }
        private void GetSalesOfficeLeaks(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<BranchLeaks> QtyList = new List<BranchLeaks>();
                cmd = new MySqlCommand("SELECT productsdata.ProductName, branchproducts.product_sno, branchproducts.BranchQty FROM  branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) order by branchproducts.Rank");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                DataTable DtBranchLeaks = vdm.SelectQuery(cmd).Tables[0];
                int i=1;
                foreach (DataRow dr in DtBranchLeaks.Rows)
                {
                    float BranchQty = 0;
                    float.TryParse(dr["BranchQty"].ToString(), out BranchQty);
                    if (BranchQty > 0)
                    {
                        BranchLeaks GetBranchLeaks = new BranchLeaks();
                        GetBranchLeaks.Sno = i++.ToString();
                        GetBranchLeaks.ProName = dr["ProductName"].ToString();
                        GetBranchLeaks.ProductID = dr["product_sno"].ToString();
                        GetBranchLeaks.Qty = BranchQty.ToString();
                        QtyList.Add(GetBranchLeaks);
                    }
                }
                string response = GetJson(QtyList);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class BranchLeaks
        {
            public string Sno { get; set; }
            public string ProName { get; set; }
            public string ProductID { get; set; }
            public string Qty { get; set; }
        }
        private void btnAgentColInventorySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string b_bid = obj.BranchID;
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                foreach (Inventorydetail o in obj.Inventorydetails)
                {
                    if (o.SNo != null)
                    {
                        int ReceivedQty = 0;
                        int.TryParse(o.ReceivedQty, out ReceivedQty);
                        cmd = new MySqlCommand("update inventory_monitor set Qty=@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                        int BalanceQty = 0;
                        int.TryParse(o.BalanceQty, out BalanceQty);
                        cmd.Parameters.Add("@Qty", BalanceQty);
                        int InvSno = 0;
                        int.TryParse(o.InvSno, out InvSno);
                        cmd.Parameters.Add("@Inv_Sno", InvSno);
                        cmd.Parameters.Add("@BranchId", b_bid);
                        vdm.Update(cmd);
                        cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                        cmd.Parameters.Add("@Qty", ReceivedQty);
                        int.TryParse(o.InvSno, out InvSno);
                        cmd.Parameters.Add("@Inv_Sno", InvSno);
                        cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                        vdm.Update(cmd);
                        cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                        cmd.Parameters.Add("@B_Inv_Sno", InvSno);
                        cmd.Parameters.Add("@Qty", ReceivedQty);
                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                        cmd.Parameters.Add("@From", b_bid);
                        cmd.Parameters.Add("@TransType", "3");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        cmd.Parameters.Add("@To", context.Session["TripdataSno"].ToString());
                        if (vdm.Update(cmd) == 0)
                        {
                            cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                            cmd.Parameters.Add("@B_Inv_Sno", InvSno);
                            cmd.Parameters.Add("@Qty", ReceivedQty);
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@From", b_bid);
                            cmd.Parameters.Add("@TransType", "3");
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@To", context.Session["TripdataSno"].ToString());
                            if (ReceivedQty != 0)
                            {
                                vdm.insert(cmd);
                            }
                        }
                    }
                }
                string msg = "Inventory Updated Successfully";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private DateTime GetLowDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            DT = dt;
            Hour = -dt.Hour;
            Min = -dt.Minute;
            Sec = -dt.Second;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;
        }
        private DateTime GetHighDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            Hour = 23 - dt.Hour;
            Min = 59 - dt.Minute;
            Sec = 59 - dt.Second;
            DT = dt;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;
        }
        private void btnDirectAgentProductSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string b_bid = obj.BranchID;
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                int Usernamesno = 1;
                foreach (orderdetail o in obj.data)
                {
                    if (o.Productsno != null)
                    {
                        string ind = "0";
                        ind = o.IndentNo;
                        if (o.IndentNo == "")
                        {
                            ind = "0";
                        }
                        if (ind != "0")
                        {
                            double DeliveryQty = 0;
                            double.TryParse(o.ReturnQty, out DeliveryQty);
                            double UnitCost = 0;
                            double LeakQty = 0;
                            DeliveryQty = Math.Round(DeliveryQty, 2);
                            double.TryParse(o.UnitCost, out UnitCost);
                            double totAmount = DeliveryQty * UnitCost;

                            cmd = new MySqlCommand("SELECT indents_subtable.Product_sno, indents_subtable.DeliveryQty, indents_subtable.unitQty, indents_subtable.UnitCost, indents.Branch_id FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo WHERE (indents_subtable.DTripId = @DtripID) AND (indents_subtable.Product_sno = @ProductID) AND (indents.Branch_id = @BranchID)");
                            cmd.Parameters.Add("@DtripID", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@ProductID", o.Productsno);
                            cmd.Parameters.Add("@BranchID", b_bid);
                            DataTable dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                            if (dtIndentData.Rows.Count > 0)
                            {
                                float Aqty = 0;
                                string DelQty = dtIndentData.Rows[0]["DeliveryQty"].ToString();
                                if (DelQty == "")
                                {
                                    Aqty = 0;
                                }
                                else
                                {
                                    float.TryParse(DelQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Aqty);
                                }
                                float Eqty = 0;
                                float.TryParse(o.ReturnQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Eqty);
                                float Lqty = 0;
                                float.TryParse(o.LeakQty, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out Lqty);
                                float TQty = Aqty - Eqty;
                                if (TQty >= 1)
                                {
                                    double EditAmount = TQty * UnitCost;
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", EditAmount);
                                    cmd.Parameters.Add("@BranchId", b_bid);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                        cmd.Parameters.Add("@Amount", EditAmount);
                                        cmd.Parameters.Add("@BranchId", b_bid);
                                        vdm.insert(cmd);
                                    }
                                    cmd = new MySqlCommand("Update branchProducts Set BranchQty=BranchQty-@BranchQty where branch_sno=@BranchId and Product_sno=@ProductId");
                                    cmd.Parameters.Add("@BranchQty", TQty);
                                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@ProductId", o.Productsno);
                                    vdm.Update(cmd);
                                }
                                else
                                {
                                    TQty = Math.Abs(TQty);
                                    double EditAmount = TQty * UnitCost;
                                    cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                                    cmd.Parameters.Add("@Amount", EditAmount);
                                    cmd.Parameters.Add("@BranchId", b_bid);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                        cmd.Parameters.Add("@Amount", EditAmount);
                                        cmd.Parameters.Add("@BranchId", b_bid);
                                        vdm.insert(cmd);
                                    }
                                    cmd = new MySqlCommand("Update branchProducts Set BranchQty=BranchQty+@BranchQty where branch_sno=@BranchId and Product_sno=@ProductId");
                                    cmd.Parameters.Add("@BranchQty", TQty);
                                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@ProductId", o.Productsno);
                                    vdm.Update(cmd);
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                cmd.Parameters.Add("@Amount", totAmount);
                                cmd.Parameters.Add("@BranchId", b_bid);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                    cmd.Parameters.Add("@Amount", totAmount);
                                    cmd.Parameters.Add("@BranchId", b_bid);
                                    vdm.insert(cmd);
                                }
                                cmd = new MySqlCommand("Update branchProducts Set BranchQty=BranchQty-@BranchQty where branch_sno=@BranchId and Product_sno=@ProductId");
                                cmd.Parameters.Add("@BranchQty", DeliveryQty);
                                cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                vdm.Update(cmd);
                            }
                            cmd = new MySqlCommand("Update indents_subtable set Status=@Status,DeliveryQty=@DeliveryQty,D_Date=@D_Date ,DelTime=@DelTime,DtripId=@DtripId,LeakQty=@LeakQty where IndentNo=@IndentNo and Product_sno=@Product_sno");
                            cmd.Parameters.Add("@IndentNo", o.IndentNo);
                            cmd.Parameters.Add("@Product_sno", o.Productsno);

                            cmd.Parameters.Add("@LeakQty", LeakQty);
                            cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                            cmd.Parameters.Add("@Status", "Delivered");
                            cmd.Parameters.Add("@D_Date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                            cmd.Parameters.Add("@DtripId", context.Session["TripdataSno"].ToString());
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,DeliveryQty,DtripId,UnitCost,D_Date,DelTime) values(@IndentNo,@Product_sno,@Status,@unitQty,@DeliveryQty,@DtripId,@UnitCost,@D_Date,@DelTime)");
                                cmd.Parameters.Add("@IndentNo", o.IndentNo);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                double unitQty = 0;
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Delivered");

                                DeliveryQty = Math.Round(DeliveryQty, 2);
                                cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                cmd.Parameters.Add("@D_Date", ServerDateCurrentdate);
                                cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                                cmd.Parameters.Add("@DtripId", context.Session["TripdataSno"].ToString());
                                if (DeliveryQty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }
                        if (ind == "0")
                        {
                            double DeliveryQty = 0;
                            double.TryParse(o.ReturnQty, out DeliveryQty);
                            double UnitCost = 0;
                            double LeakQty = 0;
                            DeliveryQty = Math.Round(DeliveryQty, 2);
                            double.TryParse(o.UnitCost, out UnitCost);
                            double totAmount = DeliveryQty * UnitCost;
                            string IndDate = context.Session["I_Date"].ToString();
                            DateTime dtIndentDate = Convert.ToDateTime(IndDate);
                            string IndentType = "";
                            IndentType = context.Session["IndentType"].ToString();
                            if (IndentType == "")
                            {
                                IndentType = "Indent1";
                            }
                            long IndentsNo = 0;
                            cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND @d2) and (indents.IndentType = @IndentType)");
                            cmd.Parameters.Add("@Branch_id", b_bid);
                            cmd.Parameters.Add("@IndentType", IndentType);
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtIndentDate));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtIndentDate));
                            DataTable dtIndentsNo = vdm.SelectQuery(cmd).Tables[0];
                            if (dtIndentsNo.Rows.Count == 0)
                            {
                                cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                                cmd.Parameters.Add("@Branch_id", b_bid);
                                cmd.Parameters.Add("@I_date", dtIndentDate);
                                cmd.Parameters.Add("@UserData_sno", Usernamesno);
                                cmd.Parameters.Add("@Status", "O");
                                cmd.Parameters.Add("@PaymentStatus", 'A');
                                cmd.Parameters.Add("@IndentType", IndentType);
                                IndentsNo = vdm.insertScalar(cmd);
                            }
                            cmd = new MySqlCommand("UPDATE  indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty,D_date=@D_date,DTripId=@DTripId,Status=@Status,UnitCost=@UnitCost,DelTime=@DelTime where Product_sno=@Product_sno and IndentNo=@IndentNo");
                            cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                            cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                            float Leak = 0;
                            float.TryParse(o.LeakQty, out Leak);
                            cmd.Parameters.Add("@LeakQty", Leak);
                            cmd.Parameters.Add("@Status", "Delivered");
                            cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@UnitCost", UnitCost);
                            cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                            cmd.Parameters.Add("@Product_sno", o.Productsno);
                            if (dtIndentsNo.Rows.Count == 0)
                            {
                                cmd.Parameters.Add("@IndentNo", IndentsNo);
                            }
                            else
                            {
                                string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                cmd.Parameters.Add("@IndentNo", strIndentsNo);
                            }
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("insert into indents_subtable (DeliveryQty,D_date,IndentNo,Product_sno,Status,unitQty,UnitCost,LeakQty,DTripId,DelTime)values(@DeliveryQty,@D_date,@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@LeakQty,@DTripId,@DelTime)");
                                cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                                cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                                if (dtIndentsNo.Rows.Count == 0)
                                {
                                    cmd.Parameters.Add("@IndentNo", IndentsNo);
                                }
                                else
                                {
                                    string strIndentsNo = dtIndentsNo.Rows[0]["IndentNo"].ToString();
                                    cmd.Parameters.Add("@IndentNo", strIndentsNo);
                                }
                                cmd.Parameters.Add("@LeakQty", Leak);
                                cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                cmd.Parameters.Add("@Status", "Delivered");
                                float unitQty = 0;
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                vdm.insert(cmd);
                            }
                            cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                            cmd.Parameters.Add("@Amount", totAmount);
                            cmd.Parameters.Add("@BranchId", b_bid);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                cmd.Parameters.Add("@Amount", totAmount);
                                cmd.Parameters.Add("@BranchId", b_bid);
                                vdm.insert(cmd);
                            }
                            cmd = new MySqlCommand("Update branchProducts Set BranchQty=BranchQty-@BranchQty where branch_sno=@BranchId and Product_sno=@ProductId");
                            cmd.Parameters.Add("@BranchQty", DeliveryQty);
                            cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                            cmd.Parameters.Add("@ProductId", o.Productsno);
                            vdm.Update(cmd);
                        }
                    }
                }
                foreach (Inventorydetail o in obj.Inventorydetails)
                {
                    int GivenQty = 0;
                    int.TryParse(o.GivenQty, out GivenQty);
                    int BalanceQty = 0;
                    int.TryParse(o.BalanceQty, out BalanceQty);
                    cmd = new MySqlCommand("update inventory_monitor set Qty=@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                    cmd.Parameters.Add("@Qty", BalanceQty);
                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@BranchId", b_bid);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                        cmd.Parameters.Add("@Qty", BalanceQty);
                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                        cmd.Parameters.Add("@BranchId", b_bid);
                        vdm.insert(cmd);
                    }
                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                    cmd.Parameters.Add("@Qty", GivenQty);
                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                    vdm.Update(cmd);
                    cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                    cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@Qty", GivenQty);
                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                    cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                    cmd.Parameters.Add("@TransType", "2");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    cmd.Parameters.Add("@To", b_bid);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                        cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                        cmd.Parameters.Add("@Qty", GivenQty);
                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                        cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@TransType", "2");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        cmd.Parameters.Add("@To", b_bid);
                        if (GivenQty != 0)
                        {
                            vdm.insert(cmd);
                        }
                    }
                }
                DateTime ReportDate = VehicleDBMgr.GetTime(vdm.conn);
                DateTime dtapril = new DateTime();
                DateTime dtmarch = new DateTime();
                int currentyear = ReportDate.Year;
                int nextyear = ReportDate.Year + 1;
                if (ReportDate.Month > 3)
                {
                    string apr = "4/1/" + currentyear;
                    dtapril = DateTime.Parse(apr);
                    string march = "3/31/" + nextyear;
                    dtmarch = DateTime.Parse(march);
                }
                if (ReportDate.Month <= 3)
                {
                    string apr = "4/1/" + (currentyear - 1);
                    dtapril = DateTime.Parse(apr);
                    string march = "3/31/" + (nextyear - 1);
                    dtmarch = DateTime.Parse(march);
                }
                string DispDate = context.Session["I_Date"].ToString();
                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                cmd = new MySqlCommand("SELECT SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS totalcost FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2)");
                cmd.Parameters.Add("@Branchid", b_bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                DataTable dtdeliveryamount = vdm.SelectQuery(cmd).Tables[0];
                float totdelamount = 0;
                float.TryParse(dtdeliveryamount.Rows[0]["totalcost"].ToString(), out totdelamount);
                cmd = new MySqlCommand("SELECT indents.Branch_id, productsdata.ProductName, indents_subtable.DeliveryQty,indents_subtable.UnitCost, indents_subtable.unitQty, indents_subtable.LeakQty , indents.IndentType, indents.IndentNo, productsdata.sno FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2) ORDER BY productsdata.Rank");
                cmd.Parameters.Add("@Branchid", b_bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                DataTable dtfinaldelivery = vdm.SelectQuery(cmd).Tables[0];
                DataView view = new DataView(dtfinaldelivery);
                DataTable dtIndent = view.ToTable(true, "IndentType", "IndentNo");
                string companycode = "";
                string gststatecode = "";
                cmd = new MySqlCommand("SELECT statemastar.gststatecode, branchdata.companycode FROM branchdata INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (branchdata.sno = @BranchID)");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                DataTable dt_GSTNo = vdm.SelectQuery(cmd).Tables[0];
                if (dt_GSTNo.Rows.Count > 0)
                {
                    companycode = dt_GSTNo.Rows[0]["companycode"].ToString();
                    gststatecode = dt_GSTNo.Rows[0]["gststatecode"].ToString();
                }
                cmd = new MySqlCommand("update Agentdc set IndDate=@IndDate where BranchId=@BranchId and IndDate=@IDate");
                cmd.Parameters.Add("@BranchId", b_bid);
                cmd.Parameters.Add("@IndDate", dtdispDate);
                cmd.Parameters.Add("@IDate", dtdispDate);
                long DcNo = 0;
                int moduleid = 1;
                if (vdm.Update(cmd) == 0)
                {
                   // cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID) AND (IndDate BETWEEN @d1 AND @d2)");
                    cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID)   AND (IndDate BETWEEN @d1 AND @d2)");
                    //cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@d1", GetLowDate(dtapril.AddDays(-1)));
                    cmd.Parameters.Add("@d2", GetHighDate(dtmarch.AddDays(-1)));
                    DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                    string agentdcNo = dtadcno.Rows[0]["Sno"].ToString();
                    cmd = new MySqlCommand("Insert Into Agentdc (BranchId,IndDate,soid,agentdcno,stateid,Companycode,moduleid) Values(@BranchId,@IndDate,@soid,@agentdcno,@stateid,@Companycode,@moduleid)");
                    cmd.Parameters.Add("@BranchId", b_bid);
                    cmd.Parameters.Add("@IndDate", dtdispDate);
                    cmd.Parameters.Add("@agentdcno", agentdcNo);
                    cmd.Parameters.Add("@soid", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@stateid", gststatecode);
                    cmd.Parameters.Add("@Companycode", companycode);
                    cmd.Parameters.Add("@moduleid", moduleid);
                    DcNo = vdm.insertScalar(cmd);
                    foreach (DataRow dr in dtIndent.Rows)
                    {
                        cmd = new MySqlCommand("Insert Into dcsubTable (DcNo,IndentNo) Values(@DcNo,@IndentNo)");
                        cmd.Parameters.Add("@DcNo", DcNo);
                        cmd.Parameters.Add("@IndentNo", dr["IndentNo"].ToString());
                        vdm.insert(cmd);
                    }
                }
                else
                {
                    cmd = new MySqlCommand("Select DcNo from Agentdc where BranchId=@BranchId and IndDate=@IDate");
                    cmd.Parameters.Add("@BranchId", b_bid);
                    cmd.Parameters.Add("@IDate", dtdispDate);
                    DataTable dtAgentDc = vdm.SelectQuery(cmd).Tables[0];
                    if (dtAgentDc.Rows.Count > 0)
                    {
                        long.TryParse(dtAgentDc.Rows[0]["DcNo"].ToString(), out DcNo);
                    }
                }
                cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.phonenumber, invmaster.InvName, inventory_monitor.Qty FROM branchdata INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (branchdata.sno = @sno)");
                cmd.Parameters.Add("@sno", b_bid);
                DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                string ProductName = "";
                string InvName = "";
                double TotalQty = 0;
                double Salevalue = 0;
                foreach (orderdetail o in obj.data)
                {
                    if (o.ReturnQty != "0")
                    {
                        float ReturnQty = 0;
                        float Rate = 0;
                        float Amount = 0;
                        float.TryParse(o.UnitCost, out Rate);
                        float.TryParse(o.ReturnQty, out ReturnQty);
                        Amount = Rate * ReturnQty;
                        ProductName += o.Product + "=" + Math.Round(ReturnQty, 2) + ";";
                        TotalQty += Math.Round(ReturnQty, 2);
                        Salevalue += Math.Round(Amount, 2);
                    }
                }
                foreach (DataRow dr in dtBranchName.Rows)
                {
                    InvName += dr["InvName"].ToString() + "=" + dr["Qty"].ToString() + ";";
                }
                if (phonenumber.Length == 10)
                {
                    string Date = DateTime.Now.ToString("dd/MM/yyyy"); ;
                    WebClient client = new WebClient();
                    //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                     string BranchSno = context.Session["CsoNo"].ToString();
                     if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                     {
                         string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2"; 

                         //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                         Stream data = client.OpenRead(baseurl);
                         StreamReader reader = new StreamReader(data);
                         string ResponseID = reader.ReadToEnd();
                         data.Close();
                         reader.Close();
                     }
                     else
                     {
                         string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2"; 
                        // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                         Stream data = client.OpenRead(baseurl);
                         StreamReader reader = new StreamReader(data);
                         string ResponseID = reader.ReadToEnd();
                         data.Close();
                         reader.Close();
                     }
                    string message = "Dear  " + BranchName + "  DCNO: " + DcNo + "  Your  indent  delivery  for  today  " + Date + "  ,  " + ProductName + " Tota  Ltrs =" + TotalQty + " Sale  Value  " + Salevalue + "  With  Bal  Inventory " + InvName + "";

                    // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                    cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                    cmd.Parameters.Add("@agentid", b_bid);
                    cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                    //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                    cmd.Parameters.Add("@msg", message);
                    cmd.Parameters.Add("@mobileno", phonenumber);
                    cmd.Parameters.Add("@msgtype", "OnlineDelivery");
                    cmd.Parameters.Add("@branchname", BranchName);
                    cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                    vdm.insert(cmd);
                }
                var jsonSerializer = new JavaScriptSerializer();
                var jsonString = String.Empty;
                context.Request.InputStream.Position = 0;
                using (var inputStream = new StreamReader(context.Request.InputStream))
                {
                    jsonString = inputStream.ReadToEnd();
                }
                string msg = "Saved Successfully";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void btnAgentProductSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string b_bid = obj.BranchID;
                string Username = "1";
                string IndentType = "SpInd1";
                string IndentDate = context.Session["I_Date"].ToString();
                DateTime ServerDateCurrentdate = Convert.ToDateTime(IndentDate);
                cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                cmd.Parameters.Add("@Branch_id", b_bid);
                cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                cmd.Parameters.Add("@UserData_sno", Username);
                cmd.Parameters.Add("@Status", "D");
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@PaymentStatus", 'A');
                long IndentNo = vdm.insertScalar(cmd);
                foreach (orderdetail o in obj.data)
                {
                    if (o.Productsno != null)
                    {
                        cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,DTripId,DeliveryQty,D_date,DelTime)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@DTripId,@DeliveryQty,@D_date,@DelTime)");
                        cmd.Parameters.Add("@IndentNo", IndentNo);
                        cmd.Parameters.Add("@Product_sno", o.Productsno);
                        double UnitCost = 0;
                        double.TryParse(o.orderunitRate, out UnitCost);
                        UnitCost = Math.Round(UnitCost, 2);
                        cmd.Parameters.Add("@UnitCost", UnitCost);
                        double unitQty = 0;
                        double Returnqty = 0;
                        double.TryParse(o.ReturnQty, out Returnqty);
                        Returnqty = Math.Round(Returnqty, 2);
                        cmd.Parameters.Add("@DeliveryQty", Returnqty);
                        cmd.Parameters.Add("@unitQty", unitQty);
                        cmd.Parameters.Add("@Status", "Delivered");
                        cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                        cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                        cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                        if (Returnqty != 0.0)
                        {
                            vdm.insert(cmd);
                            cmd = new MySqlCommand("Update branchProducts Set BranchQty=BranchQty-@BranchQty where branch_sno=@BranchId and Product_sno=@ProductId");
                            cmd.Parameters.Add("@BranchQty", Returnqty);
                            cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                            cmd.Parameters.Add("@ProductId", o.Productsno);
                            vdm.Update(cmd);
                        }
                    }
                }
                foreach (Inventorydetail o in obj.Inventorydetails)
                {
                    int GivenQty = 0;
                    int.TryParse(o.GivenQty, out GivenQty);
                    int BalanceQty = 0;
                    int.TryParse(o.BalanceQty, out BalanceQty);
                    cmd = new MySqlCommand("update inventory_monitor set Qty=@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                    cmd.Parameters.Add("@Qty", BalanceQty);
                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@BranchId", b_bid);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                        cmd.Parameters.Add("@Qty", BalanceQty);
                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                        cmd.Parameters.Add("@BranchId", b_bid);
                        vdm.insert(cmd);
                    }
                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                    cmd.Parameters.Add("@Qty", GivenQty);
                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                    vdm.Update(cmd);
                    cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                    cmd.Parameters.Add("@Qty", GivenQty);
                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                    cmd.Parameters.Add("@From", b_bid);
                    cmd.Parameters.Add("@TransType", "1");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                        cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                        cmd.Parameters.Add("@Qty", GivenQty);
                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                        cmd.Parameters.Add("@From", b_bid);
                        cmd.Parameters.Add("@TransType", "1");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                        if (GivenQty != 0)
                        {
                            vdm.insert(cmd);
                        }
                    }
                }
                string msg = "Saved Successfully";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetAgentInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                cmd = new MySqlCommand("SELECT invmaster.InvName, inventory_monitor.Qty, inventory_monitor.Sno, inventory_monitor.Inv_Sno FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno WHERE (inventory_monitor.BranchId = @BranchId)");
                cmd.Parameters.Add("@BranchId", context.Request["bid"].ToString());
                DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                DataTable dtAgentInventory = new DataTable();
                if (dtInventory.Rows.Count == 0)
                {
                    if (context.Session["dtInventory"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                        dtAgentInventory = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtAgentInventory = (DataTable)context.Session["dtInventory"];
                    }
                    int i = 1;
                    foreach (DataRow dr in dtAgentInventory.Rows)
                    {
                        Inventoryclass Inventoryget = new Inventoryclass();
                        Inventoryget.Sno = i++.ToString();
                        Inventoryget.InventorySno = dr["sno"].ToString();
                        Inventoryget.InventoryName = dr["InvName"].ToString();
                        Inventoryget.Qty = "0";
                        Inventoryget.ToadayQty = "";
                        InventoryList.Add(Inventoryget);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
                else
                {
                    int i = 1;
                    foreach (DataRow dr in dtInventory.Rows)
                    {
                        Inventoryclass GetInventory = new Inventoryclass();
                        GetInventory.Sno = i++.ToString();
                        GetInventory.InventoryName = dr["InvName"].ToString();
                        GetInventory.InventorySno = dr["Inv_Sno"].ToString();
                        GetInventory.Qty = dr["Qty"].ToString();
                        GetInventory.ToadayQty = "";
                        InventoryList.Add(GetInventory);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetDirectAgentProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Orderclass> OrderList = new List<Orderclass>();
                string IndentDate = context.Session["I_Date"].ToString();
                string IndentType = context.Session["IndentType"].ToString();
                string bid = context.Request["bid"];
                DateTime ServerDateCurrentdate = Convert.ToDateTime(IndentDate);
                DataTable dtTotalProducts = new DataTable();
                cmd = new MySqlCommand("SELECT productsdata.UnitPrice, branchproducts.Rank, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, branchproducts_1.unitprice AS Aunitprice, productsdata.sno FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SubBranch = branchproducts_1.branch_sno AND productsdata.sno = branchproducts_1.product_sno WHERE (branchproducts_1.branch_sno = @bsno) GROUP BY branchproducts_1.branch_sno, branchproducts_1.unitprice, productsdata.sno, branchproducts_1.flag ORDER BY branchproducts.Rank");
                cmd.Parameters.Add("@bsno", bid);
                DataTable dtprice = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT productsdata.ProductName, branchproducts.BranchQty , branchproducts.product_sno as ProductId FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @branchID) order by branchproducts.Rank");
                cmd.Parameters.Add("@branchID", context.Session["CsoNo"].ToString());
                DataTable dtBranchProducts = vdm.SelectQuery(cmd).Tables[0];
                dtTotalProducts.Columns.Add("product_sno");
                dtTotalProducts.Columns.Add("ProductName");
                dtTotalProducts.Columns.Add("BranchQty");
                dtTotalProducts.Columns.Add("unitQty");
                dtTotalProducts.Columns.Add("DeliveryQty");
                dtTotalProducts.Columns.Add("IndentNo");
                dtTotalProducts.Columns.Add("UnitCost");
                foreach (DataRow dr in dtBranchProducts.Rows)
                {
                    DataRow newRow = dtTotalProducts.NewRow();
                    newRow["product_sno"] = dr["ProductId"].ToString();
                    newRow["ProductName"] = dr["ProductName"].ToString();
                    newRow["BranchQty"] = dr["BranchQty"].ToString();
                    newRow["unitQty"] = "0";
                    newRow["DeliveryQty"] = "0";
                    newRow["IndentNo"] = "0";
                    newRow["UnitCost"] = "0";
                    dtTotalProducts.Rows.Add(newRow);
                }
                cmd = new MySqlCommand("SELECT productsdata.ProductName, indents_subtable.Product_sno, indents_subtable.unitQty, indents_subtable.DeliveryQty, indents_subtable.UnitCost, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @BranchID) AND (indents.I_date BETWEEN @d1 AND @d2) AND (indents.IndentType = @IndentType) GROUP BY productsdata.ProductName");
                cmd.Parameters.Add("@BranchID", bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@IndentType", IndentType);
                DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow drBranch in dtTotalProducts.Rows)
                {
                    foreach (DataRow drIndent in dtIndent.Rows)
                    {

                        if (drBranch["product_sno"].ToString() == drIndent["product_sno"].ToString())
                        {
                            float unitQty = 0;
                            float.TryParse(drIndent["unitQty"].ToString(), out unitQty);
                            float UnitCost = 0;
                            float.TryParse(drIndent["UnitCost"].ToString(), out UnitCost);
                            float DelQty = 0;
                            float.TryParse(drIndent["DeliveryQty"].ToString(), out DelQty);
                            if (DelQty == 0)
                            {
                                DelQty = unitQty;
                            }
                            drBranch["unitQty"] = unitQty;
                            drBranch["DeliveryQty"] = DelQty;

                            drBranch["UnitCost"] = UnitCost;
                            drBranch["IndentNo"] = drIndent["IndentNo"].ToString();
                        }
                    }
                }
                if (dtBranchProducts.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtTotalProducts.Rows)
                    {
                        Orderclass getOrderValue = new Orderclass();
                        getOrderValue.sno = i++.ToString();
                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                        int product_sno = 0;
                        int.TryParse(dr["product_sno"].ToString(), out product_sno);
                        getOrderValue.Productsno = product_sno;
                        string unitQty = dr["unitQty"].ToString();

                        getOrderValue.Unitqty = unitQty;
                        float UnitCost = 0;
                        float.TryParse(dr["UnitCost"].ToString(), out UnitCost);
                        if (UnitCost == 0)
                            {

                                foreach (DataRow dr1 in dtprice.Select("sno='" + dr["product_sno"].ToString() + "'"))
                                {
                                    string AgentUnitPrice = dr1["Aunitprice"].ToString();
                                    string BranchUnitPrice = dr1["BUnitPrice"].ToString();
                                    float Rate = 0;
                                    if (AgentUnitPrice != "0")
                                    {
                                        //Rate = (float)dr1["Aunitprice"];
                                        float.TryParse(dr1["Aunitprice"].ToString(), out Rate);
                                    }
                                    if (Rate == 0)
                                    {
                                        float.TryParse(dr1["BUnitPrice"].ToString(), out Rate);
                                        //Rate = (float)dr1["BUnitPrice"];
                                    }
                                    if (Rate == 0)
                                    {
                                        float.TryParse(dr1["unitprice"].ToString(), out Rate);
                                        // Rate = (float)dr1["unitprice"];
                                    }
                                    getOrderValue.Rate = Rate;
                                }
                            }
                        if (UnitCost != 0)
                        {
                            getOrderValue.Rate = UnitCost;
                        }
                        string DeliveryQty = dr["DeliveryQty"].ToString();
                        double BranchQty = 0;
                        double.TryParse(dr["BranchQty"].ToString(), out BranchQty);
                        double DQty = 0;
                        double RQty = 0;

                        if (DeliveryQty == "0")
                        {
                            DeliveryQty = unitQty;
                            double.TryParse(DeliveryQty, out DQty);
                            DQty = Math.Round(DQty, 2);
                            RQty = BranchQty - DQty;
                        }
                        double.TryParse(DeliveryQty, out DQty);
                       
                        getOrderValue.DQty = DQty;
                        getOrderValue.RQty = RQty;
                        getOrderValue.TRQty = BranchQty;
                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                        if (BranchQty != 0 || DeliveryQty != "0")
                        {
                            OrderList.Add(getOrderValue);
                        }
                    }
                }
                string response = GetJson(OrderList);
                context.Response.Write(response);

            }
            catch
            {
            }
        }
        private void GetAgentProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Orderclass> OrderList = new List<Orderclass>();

                cmd = new MySqlCommand("SELECT productsdata.UnitPrice, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, branchproducts_1.unitprice AS Aunitprice, productsdata.sno FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SubBranch = branchproducts_1.branch_sno AND  productsdata.sno = branchproducts_1.product_sno WHERE (branchproducts_1.branch_sno = @bsno) AND (branchproducts_1.flag = @flag)GROUP BY branchproducts_1.branch_sno, branchproducts_1.unitprice, productsdata.sno, branchproducts_1.flag ORDER BY productsdata.Rank");
                cmd.Parameters.Add("@flag", 1);
                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                if (dtBranch.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Orderclass getOrderValue = new Orderclass();
                        getOrderValue.sno = i++.ToString();
                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                        int prodsno = 0;
                        int.TryParse(dr["sno"].ToString(), out prodsno);
                        getOrderValue.Productsno = prodsno;
                        getOrderValue.Qty = 0;
                        getOrderValue.Total = 0;
                        if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                        {
                            getOrderValue.Desciption = "Ltrs";
                        }
                        else
                        {
                            if (dr["Units"].ToString() == "Nos")
                            {
                                getOrderValue.Desciption = "Nos";
                            }
                            else
                            {
                                getOrderValue.Desciption = "Kgs";
                            }
                        }
                        getOrderValue.Units = dr["Units"].ToString();
                        getOrderValue.Unitqty = dr["Qty"].ToString();
                        string AgentUnitPrice = dr["Aunitprice"].ToString();
                        string BranchUnitPrice = dr["BUnitPrice"].ToString();
                        float Rate = 0;
                        if (AgentUnitPrice != "0")
                        {
                            Rate = (float)dr["Aunitprice"];
                        }
                        if (Rate == 0)
                        {
                            Rate = (float)dr["BUnitPrice"];
                        }
                        if (Rate == 0)
                        {
                            Rate = (float)dr["unitprice"];
                        }
                        float Unitqty = (float)dr["Qty"];
                        float TotalRate = 0;
                        TotalRate = Rate;
                        //if (dr["Units"].ToString() == "ml")
                        //{
                        //}
                        //if (dr["Units"].ToString() == "ltr")
                        //{
                        //    TotalRate = Rate;
                        //}
                        //if (dr["Units"].ToString() == "gms")
                        //{
                        //    TotalRate = Rate;
                        //}
                        //if (dr["Units"].ToString() == "kgs")
                        //{
                        //    TotalRate = Rate;
                        //}
                        getOrderValue.Rate = (float)Rate;
                        getOrderValue.orderunitRate = (float)TotalRate;
                        getOrderValue.PrevQty = 0;
                        getOrderValue.orderunitqty = "";
                        OrderList.Add(getOrderValue);
                    }
                }
                string response = GetJson(OrderList);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void btnSOProductTransferSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string DispSno = obj.DispSno;
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("SELECT tripdata.Sno, dispatch.BranchID, dispatch_sub.IndentType FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (tripdata.Status = 'A') AND (dispatch.sno = @DispSno) and (tripdata.Permissions<>'O')");
                cmd.Parameters.Add("@DispSno", DispSno);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                string TripId = dtBranch.Rows[0]["Sno"].ToString();
                string BranchID = dtBranch.Rows[0]["BranchID"].ToString();
                string IndentType = dtBranch.Rows[0]["IndentType"].ToString();
                cmd = new MySqlCommand("update tripdata set SOTransfer=@SOTransfer where Sno=@TripID");
                cmd.Parameters.Add("@SOTransfer", "L");
                cmd.Parameters.Add("@TripID", TripId);
                vdm.Update(cmd);
                String Username = "1";
                cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus,IndentType) values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                cmd.Parameters.Add("@Branch_id", BranchID);
                cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                cmd.Parameters.Add("@UserData_sno", Username);
                cmd.Parameters.Add("@Status", "O");
                cmd.Parameters.Add("@PaymentStatus", 'A');
                cmd.Parameters.Add("@IndentType", IndentType);
                long IndentNo = vdm.insertScalar(cmd);
                foreach (orderdetail o in obj.data)
                {
                    cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                    double deliverQty = 0;
                    double.TryParse(o.ReturnQty, out deliverQty);
                    deliverQty = Math.Round(deliverQty, 2);
                    cmd.Parameters.Add("@DeliverQty", deliverQty);
                    int Prsno = 0;
                    int.TryParse(o.Productsno, out Prsno);
                    cmd.Parameters.Add("@ProductId", Prsno);
                    int TripdataSno = 0;
                    int.TryParse(TripId, out TripdataSno);
                    cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                    vdm.Update(cmd);
                    cmd = new MySqlCommand("update branchproducts set BranchQty=BranchQty+@BranchQty where branch_sno=@bnchsno and product_sno=@pdtsno");
                    double BranchQty = 0;
                    double.TryParse(o.ReturnQty, out BranchQty);
                    BranchQty = Math.Round(BranchQty, 2);
                    cmd.Parameters.Add("@BranchQty", BranchQty);
                    cmd.Parameters.Add("@bnchsno", BranchID);
                    cmd.Parameters.Add("@pdtsno", o.Productsno);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("insert into branchproducts (BranchQty,branch_sno,product_sno,LeakQty) Values(@BranchQty,@branch_sno,@product_sno,@LeakQty)");
                        double LeakQty = 0;
                        BranchQty = Math.Round(BranchQty, 2);
                        cmd.Parameters.Add("@BranchQty", BranchQty);
                        cmd.Parameters.Add("@branch_sno", BranchID);
                        cmd.Parameters.Add("@product_sno", o.Productsno);
                        cmd.Parameters.Add("@LeakQty", o.Productsno);
                        vdm.insert(cmd);
                    }
                    cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,OTripId=@OTripId,Status=@Status,DeliveryQty=@DeliveryQty where IndentNo=@IndentNo and Product_sno=@Product_sno");
                    cmd.Parameters.Add("@IndentNo", IndentNo);
                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                    double unitQty = 0;
                    double DeliveryQty = 0;
                    double.TryParse(o.ReturnQty, out DeliveryQty);
                    DeliveryQty = Math.Round(DeliveryQty, 2);
                    cmd.Parameters.Add("@unitQty", unitQty);
                    cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                    cmd.Parameters.Add("@Status", "Delivered");
                    cmd.Parameters.Add("@OTripId", TripId);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,OTripId,DeliveryQty,DtripId) values(@IndentNo,@Product_sno,@Status,@unitQty,@OTripId,@DeliveryQty,@DtripId)");
                        cmd.Parameters.Add("@IndentNo", IndentNo);
                        cmd.Parameters.Add("@Product_sno", o.Productsno);
                        cmd.Parameters.Add("@unitQty", unitQty);
                        cmd.Parameters.Add("@Status", "Delivered");
                        cmd.Parameters.Add("@DeliveryQty", DeliveryQty);
                        cmd.Parameters.Add("@OTripId", TripId);
                        cmd.Parameters.Add("@DtripId", TripId);
                        if (unitQty != 0.0)
                        {
                            vdm.insert(cmd);
                        }
                    }
                }
                foreach (Inventorydetail o in obj.Inventorydetails)
                {
                    cmd = new MySqlCommand("update tripinvdata set Remaining=Remaining-@Remaining where Tripdata_sno=@TripID and invId=@invId");
                    int TransQty = 0;
                    int.TryParse(o.TransQty, out TransQty);
                    cmd.Parameters.Add("@Remaining", TransQty);
                    cmd.Parameters.Add("@invId", o.InvSno);
                    cmd.Parameters.Add("@TripID", TripId);
                    vdm.Update(cmd);
                    cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                    cmd.Parameters.Add("@Qty", o.TransQty);
                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                    cmd.Parameters.Add("@BranchId", BranchID);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                        cmd.Parameters.Add("@Qty", o.TransQty);
                        cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                        cmd.Parameters.Add("@BranchId", BranchID);
                        vdm.insert(cmd);
                    }
                    cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                    cmd.Parameters.Add("@Qty", o.TransQty);
                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                    cmd.Parameters.Add("@From", TripId);
                    cmd.Parameters.Add("@TransType", "2");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    cmd.Parameters.Add("@To", BranchID);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                        cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                        cmd.Parameters.Add("@Qty", o.TransQty);
                        cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                        cmd.Parameters.Add("@From", TripId);
                        cmd.Parameters.Add("@TransType", "2");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        cmd.Parameters.Add("@To", BranchID);
                        if (o.TransQty != "0")
                        {
                            vdm.insert(cmd);
                        }
                    }

                }
                List<string> MsgList = new List<string>();
                string msg = "Data Transfer Successfully";
                MsgList.Add(msg);
                string responses = GetJson(MsgList);
                context.Response.Write(responses);
            }
            catch (Exception ex)
            {
                List<string> MsgList = new List<string>();
                string msg = ex.Message;
                MsgList.Add(msg);
                string responses = GetJson(MsgList);
                context.Response.Write(responses);
            }
        }
        private void GetSOPlantDispatches(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string DispatchType = context.Request["DispatchType"];
                DataTable dtDesp = new DataTable();
                List<DespClass> DispList = new List<DespClass>();
                if (DispatchType == "SalesTransfer")
                {
                    string EMPID = context.Session["UserSno"].ToString();
                    cmd = new MySqlCommand("SELECT dispatch.sno,  dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno  WHERE  (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpID) and (tripdata.SOTransfer is NULL)");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    dtDesp = vdm.SelectQuery(cmd).Tables[0];
                    if (dtDesp.Rows.Count == 0)
                    {
                        cmd = new MySqlCommand("SELECT dispatch.sno,  dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno  WHERE  (tripdata.Status = 'A') AND (tripdata.DispatcherID = @EmpID) and (tripdata.SOTransfer is NULL)");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        dtDesp = vdm.SelectQuery(cmd).Tables[0];
                    }
                }
                if (DispatchType == "ReturnDC")
                {
                    cmd = new MySqlCommand("SELECT dispatch.sno,  dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno  WHERE  (tripdata.EmpId = @EmpID) and (tripdata.SOTransfer =@SOTransfer)");
                    cmd.Parameters.Add("@SOTransfer", "L");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    dtDesp = vdm.SelectQuery(cmd).Tables[0];
                    if (dtDesp.Rows.Count == 0)
                    {
                        cmd = new MySqlCommand("SELECT dispatch.sno,  dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno  WHERE  (tripdata.DispatcherID = @EmpID) and (tripdata.SOTransfer =@SOTransfer)");
                        cmd.Parameters.Add("@SOTransfer", "L");
                        cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                        dtDesp = vdm.SelectQuery(cmd).Tables[0];
                    }
                }
                if (DispatchType == "")
                {
                    cmd = new MySqlCommand("SELECT dispatch.sno,  dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno  WHERE  (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpID)");
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    dtDesp = vdm.SelectQuery(cmd).Tables[0];
                }
                if (dtDesp.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtDesp.Rows)
                    {
                        DespClass GetDesp = new DespClass();
                        GetDesp.Sno = dr["sno"].ToString();
                        GetDesp.DispName = dr["DispName"].ToString();
                        DispList.Add(GetDesp);
                    }
                    string response = GetJson(DispList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public class DespClass
        {
            public string Sno { get; set; }
            public string DispName { get; set; }
        }
        private void SoSalesOFFIceProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string dispSno = context.Request["DispSno"];
                cmd = new MySqlCommand("SELECT tripdata.Sno FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (tripdata.Status = 'A') AND (dispatch.sno = @DispSno)  and (tripdata.Permissions<>'O')");
                cmd.Parameters.Add("@DispSno", dispSno);
                DataTable dtTripId = vdm.SelectQuery(cmd).Tables[0];
                List<TripSubData> SubTriplist = new List<TripSubData>();
                if (dtTripId.Rows.Count > 0)
                {
                    string TripId = dtTripId.Rows[0]["Sno"].ToString();
                    cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, tripsubdata.DeliverQty, tripsubdata.Qty FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripdata.Sno = @TripID) GROUP BY productsdata.ProductName");
                    cmd.Parameters.Add("@TripID", TripId);
                    DataTable dtSubTripdata = vdm.SelectQuery(cmd).Tables[0];
                    //cmd = new MySqlCommand("");
                    if (dtSubTripdata.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtSubTripdata.Rows)
                        {
                            TripSubData getTripSubData = new TripSubData();
                            getTripSubData.Sno = i++.ToString();
                            getTripSubData.ProductId = dr["ProductId"].ToString();
                            getTripSubData.ProductName = dr["ProductName"].ToString();
                            double Qty = 0;
                            double.TryParse(dr["Qty"].ToString(), out Qty);
                            double DeliverQty = 0;
                            double.TryParse(dr["DeliverQty"].ToString(), out DeliverQty);
                            double RemQty = Qty - DeliverQty;
                            getTripSubData.remQty = Math.Round(RemQty, 2).ToString();
                            SubTriplist.Add(getTripSubData);
                        }
                    }
                }
                string response = GetJson(SubTriplist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void SoSalesOFFIceInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string dispSno = context.Request["DispSno"];
                cmd = new MySqlCommand("SELECT tripdata.Sno FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (tripdata.Status = 'A') AND (dispatch.sno = @DispSno)  and (tripdata.Permissions<>'O')");
                cmd.Parameters.Add("@DispSno", dispSno);
                DataTable dtTripId = vdm.SelectQuery(cmd).Tables[0];
                List<TripInvData> TripInvlist = new List<TripInvData>();
                if (dtTripId.Rows.Count > 0)
                {
                    string TripId = dtTripId.Rows[0]["Sno"].ToString();
                    cmd = new MySqlCommand("SELECT  tripdata.Sno, tripinvdata.invid, invmaster.InvName, tripinvdata.Remaining FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @TripID)GROUP BY invmaster.InvName");
                    cmd.Parameters.Add("@TripID", TripId);
                    DataTable dtSubTripdata = vdm.SelectQuery(cmd).Tables[0];
                    if (dtSubTripdata.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtSubTripdata.Rows)
                        {
                            TripInvData getTripSubData = new TripInvData();
                            getTripSubData.Sno = i++.ToString();
                            getTripSubData.InventorySno = dr["invid"].ToString();
                            getTripSubData.InventoryName = dr["InvName"].ToString();
                            getTripSubData.Qty = dr["Remaining"].ToString();
                            TripInvlist.Add(getTripSubData);
                        }
                    }
                }
                string response = GetJson(TripInvlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetPlantDispatchInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT invmaster.InvName, tripinvdata.Qty, invmaster.sno FROM tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where (tripinvdata.Tripdata_sno=@TripSno) Order by invmaster.sno");
                cmd.Parameters.Add("@TripSno", context.Session["TripdataSno"].ToString());
                DataTable dtSubTripdata = vdm.SelectQuery(cmd).Tables[0];
                List<TripInvData> TripInvlist = new List<TripInvData>();
                if (dtSubTripdata.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtSubTripdata.Rows)
                    {
                        TripInvData getTripSubData = new TripInvData();
                        getTripSubData.Sno = i++.ToString();
                        getTripSubData.InventorySno = dr["sno"].ToString();
                        getTripSubData.InventoryName = dr["InvName"].ToString();
                        getTripSubData.Qty = dr["Qty"].ToString();
                        TripInvlist.Add(getTripSubData);
                    }
                }
                string response = GetJson(TripInvlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class TripInvData
        {
            public string Sno { get; set; }
            public string InventoryName { get; set; }
            public string InventorySno { get; set; }
            public string Qty { get; set; }
        }
        private void GetPlantDispatchProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.ProductId, tripsubdata.Qty FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripsubdata.Tripdata_sno = @TripSno)");
                cmd.Parameters.Add("@TripSno", context.Session["TripdataSno"].ToString());
                DataTable dtSubTripdata = vdm.SelectQuery(cmd).Tables[0];
                List<TripSubData> SubTriplist = new List<TripSubData>();
                if (dtSubTripdata.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtSubTripdata.Rows)
                    {
                        TripSubData getTripSubData = new TripSubData();
                        getTripSubData.Sno = i++.ToString();
                        getTripSubData.ProductId = dr["ProductId"].ToString();
                        getTripSubData.ProductName = dr["ProductName"].ToString();
                        getTripSubData.Qty = dr["Qty"].ToString();
                        SubTriplist.Add(getTripSubData);
                    }
                }
                string response = GetJson(SubTriplist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class TripSubData
        {
            public string Sno { get; set; }
            public string ProductName { get; set; }
            public string ProductId { get; set; }
            public string Qty { get; set; }
            public string remQty { get; set; }
        }
        private void GetSODispatchClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT DispName, sno, Branch_Id, BranchID FROM (SELECT dispatch.DispName, dispatch.sno, dispatch.Branch_Id, branchroutes.BranchID FROM dispatch_sub INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno RIGHT OUTER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (NOT (branchroutes.BranchID = @BranchID)) OR (NOT (dispatch.Branch_Id = @branchid))) Result  WHERE (BranchID = @BranchID)GROUP BY DispName");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                DataTable dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                List<SalesOfficeDispatches> SOClist = new List<SalesOfficeDispatches>();
                if (dtRoutedata.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtRoutedata.Rows)
                    {
                        string RouteId = context.Session["RouteId"].ToString();
                        if (RouteId != dr["sno"].ToString())
                        {
                            SalesOfficeDispatches getSOD = new SalesOfficeDispatches();
                            getSOD.Dispsno = dr["sno"].ToString();
                            getSOD.DispName = dr["DispName"].ToString();
                            SOClist.Add(getSOD);
                        }
                    }
                }
                string response = GetJson(SOClist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class SalesOfficeDispatches
        {
            public string DispName { get; set; }
            public string Dispsno { get; set; }
        }
        private void DispatchReportClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT dispatch.DispName, empmanage.UserName FROM  triproutes INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno WHERE (tripdata.ATripid = @ATripid)");
                cmd.Parameters.Add("@ATripid", context.Session["TripdataSno"].ToString());
                DataTable dtDisp = vdm.SelectQuery(cmd).Tables[0];
                List<DispClass> Displist = new List<DispClass>();
                if (dtDisp.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtDisp.Rows)
                    {
                        DispClass getDispClass = new DispClass();
                        getDispClass.Sno = i++.ToString();
                        getDispClass.Dispname = dr["DispName"].ToString();
                        getDispClass.UserName = dr["UserName"].ToString();
                        Displist.Add(getDispClass);
                    }
                }
                string response = GetJson(Displist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class DispClass
        {
            public string Sno { get; set; }
            public string Dispname { get; set; }
            public string UserName { get; set; }
        }
        private void GetRouteEmployeeNames(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteID = context.Request["TripId"];
                cmd = new MySqlCommand("SELECT tripdata.EmpId, empmanage.UserName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno WHERE (tripdata.ATripid = @Atripid) AND (triproutes.RouteID = @RouteID) and (tripdata.Status=@Status)");
                cmd.Parameters.Add("@ATripid", context.Session["TripdataSno"].ToString());
                cmd.Parameters.Add("@RouteID", RouteID);
                cmd.Parameters.Add("@Status", "A");
                DataTable dtEmps = vdm.SelectQuery(cmd).Tables[0];
                List<Employee> Employeelist = new List<Employee>();
                if (dtEmps.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmps.Rows)
                    {
                        Employee b = new Employee() { Sno = dr["EmpId"].ToString(), UserName = dr["UserName"].ToString() };
                        Employeelist.Add(b);
                    }
                }
                string response = GetJson(Employeelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetDispname(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["BranchSno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    List<SoDispatchNames> SoDispatchNameslist = new List<SoDispatchNames>();
                    cmd = new MySqlCommand("SELECT dispatch.DispName, dispatch.sno FROM branchdata INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID INNER JOIN dispatch ON branchroutes.BranchID = dispatch.BranchID WHERE (branchdata.SalesOfficeID = @SOID) OR (branchroutes.BranchID = @BranchID) GROUP BY dispatch.DispName");
                    //cmd = new MySqlCommand("SELECT DispName, sno, Branch_Id, BranchID FROM (SELECT dispatch.DispName, dispatch.sno, dispatch.Branch_Id, branchroutes.BranchID FROM dispatch_sub INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno RIGHT OUTER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (NOT (branchroutes.BranchID = @BranchID)) OR (NOT (dispatch.Branch_Id = @branchid))) Result  WHERE (BranchID = @BranchID)GROUP BY DispName");
                    string branchsno = context.Session["BranchSno"].ToString();
                    

                    cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());
                    cmd.Parameters.Add("@SOID", context.Session["BranchSno"].ToString());
                    DataTable dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                    if (dtRoutedata.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtRoutedata.Rows)
                        {
                            SoDispatchNames GetSoDispatchName = new SoDispatchNames();
                            GetSoDispatchName.sno = dr["sno"].ToString();
                            GetSoDispatchName.DispName = dr["DispName"].ToString();
                            SoDispatchNameslist.Add(GetSoDispatchName);
                        }
                        string response = GetJson(SoDispatchNameslist);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        public class SoDispatchNames
        {
            public string DispName { get; set; }
            public string sno { get; set; }
        }
        private void IndentReportSaveclick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                if (context.Session["BranchSno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string phonenumber = context.Request["MobNo"];
                    string DispatchSno = context.Request["DispatchSno"];
                    string DispatchName = context.Request["DispatchName"];
                    string ProductName = "";
                    //DateTime fromdate = DateTime.Now;
                    DateTime fromdate = VehicleDBMgr.GetTime(vdm.conn);
                    string[] datestrig = fromdate.ToString("dd-MM-yyyy HH:mm").Split(' ');
                    if (datestrig.Length > 1)
                    {
                        if (datestrig[0].Split('-').Length > 0)
                        {
                            string[] dates = datestrig[0].Split('-');
                            string[] times = datestrig[1].Split(':');
                            fromdate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                        }
                    }
                    ////Ravi
                    cmd = new MySqlCommand("SELECT SUM(ff.unitQty) AS unitQty, ff.ProductName,ff.sno as product_sno FROM (SELECT branchroutesubtable.BranchID FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo WHERE (dispatch.sno = @dispatchSno)) branches INNER JOIN (SELECT unitQty, ProductName, Branch_id,sno FROM  (SELECT  indents_subtable.unitQty, productsdata.ProductName,productsdata.sno, indents_1.Branch_id FROM indents indents_1 INNER JOIN indents_subtable ON indents_1.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents_1.I_date BETWEEN @d1 AND @d2)) indents) ff ON branches.BranchID = ff.Branch_id GROUP BY ff.ProductName");
                    ////cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS unitQty, branchproducts.product_sno, productsdata.ProductName FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN branchproducts ON dispatch.BranchID = branchproducts.branch_sno AND indents_subtable.Product_sno = branchproducts.product_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchSno) AND (indents.I_date BETWEEN @d1 AND @d2) GROUP BY branchproducts.product_sno ORDER BY branchproducts.Rank");
                    cmd.Parameters.Add("@dispatchSno", DispatchSno);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(fromdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(fromdate));
                    DataTable dtTotalIndent = vdm.SelectQuery(cmd).Tables[0];
                    cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, SUM(offer_indents_sub.offer_indent_qty) AS unitQty FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchproducts ON dispatch.BranchID = branchproducts.branch_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType, I_modified_by FROM offer_indents WHERE (indent_date BETWEEN @starttime AND @endtime)) offerindent ON branchroutesubtable.BranchID = offerindent.agent_id INNER JOIN offer_indents_sub ON offerindent.idoffer_indents = offer_indents_sub.idoffer_indents AND branchproducts.product_sno = offer_indents_sub.product_id WHERE (dispatch.sno = @dispatchSno) GROUP BY branchproducts.product_sno ORDER BY branchproducts.Rank");
                    cmd.Parameters.Add("@dispatchSno", DispatchSno);
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(fromdate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(fromdate));
                    DataTable dtTotalOfferIndent = vdm.SelectQuery(cmd).Tables[0];
                    double TotalQty = 0;
                    if (dtTotalIndent.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTotalIndent.Rows)
                        {
                            double offerqty = 0;
                            foreach (DataRow droffer in dtTotalOfferIndent.Select(("product_sno='" + dr["product_sno"].ToString() + "'")))
                            {
                                double.TryParse(droffer["unitQty"].ToString(), out offerqty);

                            }
                            double unitQty = 0;
                            double totunitQty = 0;
                            double.TryParse(dr["unitQty"].ToString(), out unitQty);
                            totunitQty = unitQty + offerqty;
                            ProductName += dr["ProductName"].ToString() + "=" + Math.Round(totunitQty, 2) + ";" + "\r\n";
                            //TotalQty += Math.Round(unitQty, 2);
                            TotalQty += Math.Round(totunitQty, 2);
                        }
                    }
                    if (phonenumber.Length != 10)
                    {
                        cmd = new MySqlCommand("SELECT mobilenotable.PhoneNumber, dispatch.DispName FROM mobilenotable INNER JOIN dispatch ON mobilenotable.DispNo = dispatch.sno WHERE (mobilenotable.DispNo = @DispNo) and (mobilenotable.MsgType=@MsgType)");
                        cmd.Parameters.Add("@DispNo", DispatchSno);
                        cmd.Parameters.Add("@MsgType", "1");
                        DataTable dtPhoneNumbers = vdm.SelectQuery(cmd).Tables[0];
                        if (dtPhoneNumbers.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtPhoneNumbers.Rows)
                            {
                                phonenumber = dr["PhoneNumber"].ToString();
                                DispatchName = dr["DispName"].ToString();
                                if (phonenumber.Length == 10)
                                {
                                    string frmdate = fromdate.ToString("dd/MM/yyyy");
                                    WebClient client = new WebClient();
                                    //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                                     string BranchSno = context.Session["CsoNo"].ToString();
                                     if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                                     {
                                         string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 

                                         //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&type=1";
                                         Stream data = client.OpenRead(baseurl);
                                         StreamReader reader = new StreamReader(data);
                                         string ResponseID = reader.ReadToEnd();
                                         data.Close();
                                         reader.Close();
                                         Thread.Sleep(100);
                                     }
                                     else
                                     {
                                         string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 

                                         //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&type=1";
                                         Stream data = client.OpenRead(baseurl);
                                         StreamReader reader = new StreamReader(data);
                                         string ResponseID = reader.ReadToEnd();
                                         data.Close();
                                         reader.Close();
                                         Thread.Sleep(100);
                                     }

                                    string message = "" + DispatchName + "  ,  + Indent  For  Date: " + frmdate + "  Completed " + ProductName + "TotalQty =" + TotalQty + " ";
                                    // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                                    cmd = new MySqlCommand("insert into smsinfo (agentid,branchid,msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                                    cmd.Parameters.Add("@agentid", DispatchSno);
                                    cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                                    //cmd.Parameters.Add("@mainbranch", context.Session["SuperBranch"].ToString());
                                    cmd.Parameters.Add("@msg", message);
                                    cmd.Parameters.Add("@mobileno", phonenumber);
                                    cmd.Parameters.Add("@msgtype", "IndentReporting");
                                    cmd.Parameters.Add("@branchname", DispatchName);
                                    cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                                    vdm.insert(cmd);
                                }
                            }
                            string errmsg = "Message Sent Successfully";
                            string errresponse = GetJson(errmsg);
                            context.Response.Write(errresponse);
                        }
                    }
                    else
                    {
                        if (phonenumber.Length == 10)
                        {
                            string frmdate = fromdate.ToString("dd/MM/yyyy");
                            WebClient client = new WebClient();
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                            string BranchSno = context.Session["CsoNo"].ToString();
                            if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                            {
                                string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 

                               // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&type=1";
                                Stream data = client.OpenRead(baseurl);
                                StreamReader reader = new StreamReader(data);
                                string ResponseID = reader.ReadToEnd();
                                data.Close();
                                reader.Close();
                            }
                            else
                            {
                                string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 

                                //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=%20" + DispatchName + "%20,%20 + Indent%20For%20Date:%20" + frmdate + "%20%20Completed%20" + ProductName + "TotalQty =" + TotalQty + "&type=1";
                                Stream data = client.OpenRead(baseurl);
                                StreamReader reader = new StreamReader(data);
                                string ResponseID = reader.ReadToEnd();
                                data.Close();
                                reader.Close();
                            }

                            string message = "" + DispatchName + "  ,  + Indent  For  Date:  " + frmdate + "  Completed  " + ProductName + "TotalQty =" + TotalQty + " ";
                            // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                            cmd = new MySqlCommand("insert into smsinfo (agentid,branchid,msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                            cmd.Parameters.Add("@agentid", DispatchSno);
                            cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                            //cmd.Parameters.Add("@mainbranch", context.Session["SuperBranch"].ToString());
                            cmd.Parameters.Add("@msg", message);
                            cmd.Parameters.Add("@mobileno", phonenumber);
                            cmd.Parameters.Add("@msgtype", "IndentReporting");
                            cmd.Parameters.Add("@branchname", DispatchName);
                            cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                            vdm.insert(cmd);
                            string errmsg = "Message Sent Successfully";
                            string errresponse = GetJson(errmsg);
                            context.Response.Write(errresponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.ToString();
                string errresponse = GetJson(errmsg);
                context.Response.Write(errresponse);
            }
        }
        //private void logout(HttpContext context)
        //{
        //    string msg = "Success";
        //    context.Session.Abandon();
        //    context.Session["UserName"] = null;
        //    context.Session["userdata_sno"] = null;
        //    //Response.Redirect("login.aspx");
        //    string errresponse = GetJson(msg);
        //    context.Response.Write(errresponse);
        //}
        //........................Get Permission for USER......../////////////////
        private void GetPermissions(HttpContext context)
        {
            List<UserPermission> GetList = new List<UserPermission>();
            UserPermission GetPermission = new UserPermission();
            if (context.Session["Permissions"] == null)
            {
                string errmsg = "Session Expired";
                string errresponse = GetJson(errmsg);
                context.Response.Write(errresponse);
            }
            else
            {
                GetPermission.UserName = context.Session["UserName"].ToString();
                GetPermission.Permision = context.Session["Permissions"].ToString();
                GetPermission.Count = context.Session["count"].ToString();
                GetList.Add(GetPermission);
                string errresponse = GetJson(GetList);
                context.Response.Write(errresponse);
            }
        }
        public class UserPermission
        {
            public string UserName { get; set; }
            public string Count { get; set; }
            public string Permision { get; set; }
        }
        //........................Password Change Details......../////////////////
        private void changepassword(HttpContext context)
        {
            string msg = "Success";

            try
            {
                VehicleDBMgr vdm = new VehicleDBMgr();
                DataTable dt = new DataTable();
                String UserName = context.Request["loginname"].ToString();// txtUserName.Text, 
                String PassWord = context.Request["UID"].ToString(); //txtPassword.Text;
                String currentPassWord = context.Request["PWDConfirm"].ToString(); //txtPassword.Text;
                cmd = new MySqlCommand("select * from empmanage where UserName=@UN and Password=@Pwd");
                cmd.Parameters.Add("@UN", UserName);
                cmd.Parameters.Add("@Pwd", PassWord);
                DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                if (dtemp.Rows.Count > 0)
                {
                    cmd = new MySqlCommand("update  empmanage set Password=@Password WHERE Sno=@sno");
                    cmd.Parameters.Add("@Password", currentPassWord);
                    cmd.Parameters.Add("@sno", dtemp.Rows[0]["Sno"].ToString());
                    vdm.Update(cmd);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            string errresponse = GetJson(msg);
            context.Response.Write(errresponse);
        }
        //........................Login Details......../////////////////
        private void ValidateLogin(HttpContext context)
        {
            string msg = "Success";
            string status = "0";
            try
            {
                VehicleDBMgr vdm = new VehicleDBMgr();
                DataTable dt = new DataTable();
                String UserName = context.Request["UID"].ToString();// txtUserName.Text, 
                String PassWord = context.Request["PWD"].ToString(); //txtPassword.Text;
                string dispatchpassword = "0";
                cmd = new MySqlCommand("select * from empmanage where UserName=@UN and Password=@Pwd and flag=@flag");
                cmd.Parameters.Add("@UN", UserName);
                cmd.Parameters.Add("@Pwd", PassWord);
                cmd.Parameters.Add("@flag", "1");
                DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                if (dtemp.Rows.Count > 0)
                {
                    context.Session["logingname"] = UserName;
                    context.Session["PWD"] = PassWord;
                    string LevelType = dtemp.Rows[0]["LevelType"].ToString();
                    cmd = new MySqlCommand("SELECT Sno, EmpId, AssignDate, Status, DispatcherID,Password FROM tripdata WHERE (DispatcherID = @EmpId) AND (Status = 'A')");
                    cmd.Parameters.Add("@EmpId", dtemp.Rows[0]["Sno"].ToString());
                    DataTable dtdispAssign = vdm.SelectQuery(cmd).Tables[0];
                    if (dtdispAssign.Rows.Count > 0)
                    {
                        LevelType = "SODispatcher";
                        status = "1";
                        dispatchpassword = dtdispAssign.Rows[0]["Password"].ToString();
                    }
                    if (PassWord != dispatchpassword)
                    {
                        if (LevelType == "Dispatcher" || LevelType == "SODispatcher")
                        {
                            if (status == "1")
                            {
                                cmd = new MySqlCommand("SELECT branchroutes.BranchID, tripdata.Sno,tripdata.I_Date,triproutes.RouteID,dispatch_sub.IndentType,dispatch.Disptype FROM  tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno WHERE (tripdata.Status = 'A') AND (tripdata.DispatcherID = @EmpId)GROUP BY dispatch.DispName");
                                cmd.Parameters.Add("@EmpId", dtemp.Rows[0]["Sno"].ToString());
                                dt = vdm.SelectQuery(cmd).Tables[0];
                            }
                            if (status == "0")
                            {
                                cmd = new MySqlCommand("SELECT  T1.Sno, T1.I_Date, T1.dispsno, t2.BranchID, t2.IndentType, T1.DispType,T1.RouteID FROM (SELECT tripdata.Sno, tripdata.I_Date, triproutes.RouteID,dispatch.sno AS dispsno, dispatch.DispType FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (tripdata.EmpId = @empid) AND (tripdata.Status = 'A') GROUP BY dispatch.DispName) T1 INNER JOIN (SELECT  dispatch_sub.dispatch_sno, branchroutes.BranchID, dispatch_sub.IndentType FROM dispatch_sub INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno) t2 ON t2.dispatch_sno = T1.dispsno GROUP BY T1.dispsno");
                                //cmd = new MySqlCommand("SELECT branchroutes.BranchID, tripdata.Sno, tripdata.I_Date, triproutes.RouteID, dispatch_sub.IndentType, dispatch.DispType FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno WHERE (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId) GROUP BY dispatch.DispName");
                                cmd.Parameters.Add("@EmpId", dtemp.Rows[0]["Sno"].ToString());
                                dt = vdm.SelectQuery(cmd).Tables[0];
                            }
                            if (dt.Rows.Count > 0)
                            {
                                context.Session["UserName"] = "";
                                context.Session["userdata_sno"] = dtemp.Rows[0]["UserData_sno"].ToString();
                                context.Session["UserSno"] = dtemp.Rows[0]["Sno"].ToString(); ;
                                context.Session["count"] = "";
                                context.Session["routearray"] = "";
                                context.Session["RouteId"] = dt.Rows[0]["RouteID"].ToString();
                                context.Session["TripdataSno"] = dt.Rows[0]["Sno"].ToString();
                                context.Session["TripID"] = dt.Rows[0]["Sno"].ToString();
                                context.Session["Permissions"] = "";
                                context.Session["Salestype"] = "Plant";
                                context.Session["BranchSno"] = "";
                                if (status == "0")
                                {
                                    context.Session["LevelType"] = dtemp.Rows[0]["LevelType"].ToString();
                                    context.Session["Permissions"] = dtemp.Rows[0]["LevelType"].ToString();
                                }
                                if (status == "1")
                                {
                                    context.Session["LevelType"] = "SODispatcher";
                                    context.Session["Permissions"] = "SODispatcher";
                                }
                                context.Session["PlantEmpId"] = dtemp.Rows[0]["Sno"].ToString();
                                context.Session["PlantDispSno"] = dt.Rows[0]["Sno"].ToString();
                                context.Session["DispDate"] = dt.Rows[0]["I_Date"].ToString();
                                context.Session["I_Date"] = dt.Rows[0]["I_Date"].ToString();
                                context.Session["userdata_sno"] = dtemp.Rows[0]["UserData_sno"].ToString();
                                context.Session["UserName"] = dtemp.Rows[0]["UserName"].ToString();
                                context.Session["CsoNo"] = dtemp.Rows[0]["Branch"].ToString();
                                context.Session["IndentType"] = dt.Rows[0]["IndentType"].ToString();
                                context.Session["DispType"] = dt.Rows[0]["Disptype"].ToString();
                            }
                            else
                            {
                                msg = "Trip Not Assigned on this UserName";
                            }
                        }
                        else
                        {
                          //  cmd = new MySqlCommand("SELECT  tripdata.Status, tripdata.AssignDate, tripdata.ATripid, tripdata.I_Date, tripdata.Sno, tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno, dispatch.DispType, empmanage.UserName,branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (tripdata.Status = 'A') AND (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                            cmd = new MySqlCommand("SELECT tripdata.Status, tripdata.AssignDate,tripdata.ATripId, tripdata.I_Date, tripdata.Sno,  tripdata.Permissions, tripdata.EmpId, empmanage.Sno AS EmpSno,dispatch.DispType, empmanage.UserName, branchdata.sno AS BranchSno, empmanage.Userdata_sno, empmanage.LevelType, empmanage.Branch, salestypemanagement.salestype, triproutes.RouteID, dispatch_sub.IndentType FROM  tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (tripdata.Status = 'A') AND (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                            cmd.Parameters.Add("@UN", UserName);
                            cmd.Parameters.Add("@Pwd", PassWord);
                            dt = vdm.SelectQuery(cmd).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                string Permissions = dt.Rows[0]["Permissions"].ToString();
                                if (Permissions == "D;C")
                                {
                                    msg = "Sorry,Please Login Offline Application C.vyshnavi.net";
                                }
                                else
                                {
                                    context.Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                                    context.Session["userdata_sno"] = dt.Rows[0]["UserData_sno"].ToString();
                                    context.Session["UserSno"] = dt.Rows[0]["EmpSno"].ToString();
                                    context.Session["LevelType"] = dt.Rows[0]["LevelType"].ToString();
                                    context.Session["AssignDate"] = dt.Rows[0]["AssignDate"].ToString();
                                    context.Session["I_Date"] = dt.Rows[0]["I_Date"].ToString();
                                    int count = 0;
                                    string Routes = "";
                                    string[] routearray = new String[0] { };
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        if (dt.Rows.Count > 1)
                                        {
                                            string RouteId = dr["RouteId"].ToString();
                                            if (RouteId != "")
                                            {
                                                Routes += dr["RouteId"].ToString() + "@";
                                                count++;
                                            }
                                        }
                                    }
                                    routearray = Routes.Split('@');
                                    context.Session["count"] = count;
                                    context.Session["routearray"] = routearray;
                                    context.Session["RouteId"] = dt.Rows[0]["RouteId"].ToString();
                                    context.Session["TripdataSno"] = dt.Rows[0]["Sno"].ToString();
                                    context.Session["TripID"] = dt.Rows[0]["Sno"].ToString();
                                    context.Session["Permissions"] = dt.Rows[0]["Permissions"].ToString();
                                    context.Session["Salestype"] = dt.Rows[0]["salestype"].ToString();
                                    context.Session["BranchSno"] = dt.Rows[0]["BranchSno"].ToString();
                                    context.Session["CsoNo"] = dt.Rows[0]["BranchSno"].ToString();
                                    //context.Session["IndentType"] = "Indent1"; //dt.Rows[0]["IndentType"].ToString();
                                    context.Session["IndentType"] = dt.Rows[0]["IndentType"].ToString(); ; //dt.Rows[0]["IndentType"].ToString();

                                    context.Session["DispType"] = dt.Rows[0]["DispType"].ToString();
                                    context.Session["ATripId"] = dt.Rows[0]["ATripId"].ToString();
                                }
                            }
                            else
                            {
                                msg = "Trip Not Assigned on this UserName";
                            }
                        }
                    }
                    if (PassWord == dispatchpassword)
                    {
                        msg = "Change Password";
                    }
                }
                else
                {
                    msg = "Invalid UserName and Password";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            string errresponse = GetJson(msg);
            context.Response.Write(errresponse);
        }
        //........................Return Details......../////////////////
        private void btnReturnsVarifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        if (o.ProductID != null)
                        {
                            string Permissions = context.Session["Permissions"].ToString();
                            if (Permissions == "SODispatcher")
                            {
                                cmd = new MySqlCommand("Update Leakages set VarifyReturnStatus=@VarifyReturnStatus,VTripID=@VTripID where ProductID=@ProductID and TripID=@TripID and VarifyReturnStatus=@VRS");
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@VarifyReturnStatus", 'V');
                                cmd.Parameters.Add("@TripID", o.TripID);
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VRS", 'P');
                                vdm.Update(cmd);
                                cmd = new MySqlCommand("Update Branchproducts set BranchQty=BranchQty+@BranchQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                                double ReturnQty = 0;
                                double.TryParse(o.ReturnsQty, out ReturnQty);
                                ReturnQty = Math.Round(ReturnQty, 2);
                                cmd.Parameters.Add("@BranchQty", ReturnQty);
                                cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@Product_sno", o.ProductID);
                                vdm.Update(cmd);
                            }
                            else
                            {
                                cmd = new MySqlCommand("Update Leakages set Vreturns=@Vreturns,VarifyReturnStatus=@VarifyReturnStatus,VTripID=@VTripID  where ProductID=@ProductID and TripID=@TripID and VarifyReturnStatus=@VRS");
                                double ReturnQty = 0;
                                double.TryParse(o.ReturnsQty, out ReturnQty);
                                ReturnQty = Math.Round(ReturnQty, 2);
                                cmd.Parameters.Add("@Vreturns", ReturnQty);
                                //float TotalLeaks = 0;
                                //float.TryParse(o.LeaksQty, out TotalLeaks);
                                //cmd.Parameters.Add("@VLeaks", TotalLeaks);
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@TripID", o.TripID);
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VarifyReturnStatus", 'V');
                                cmd.Parameters.Add("@VRS", 'P');
                                //if (ReturnQty != 0.0 )
                                //{
                                vdm.Update(cmd);
                                //}
                            }
                        }
                    }
                    string Msg = "Returns Successfully Updated";
                    string response = GetJson(Msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        //........................Leaks Details......../////////////////
        private void btnLeakVarifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        if (o.ProductID != null)
                        {
                            string Permissions = context.Session["Permissions"].ToString();
                            if (Permissions == "SODispatcher")
                            {
                                cmd = new MySqlCommand("Update Leakages set VarifyStatus=@VarifyStatus,VTripID=@VTripID where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VS");
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@VarifyStatus", 'V');
                                cmd.Parameters.Add("@TripID", o.TripID);
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VS", 'P');
                                vdm.Update(cmd);
                                cmd = new MySqlCommand("Update Branchproducts set LeakQty=LeakQty+@LeakQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                                double TotalLeaks = 0;
                                double.TryParse(o.LeaksQty, out TotalLeaks);
                                TotalLeaks = Math.Round(TotalLeaks, 2);
                                cmd.Parameters.Add("@LeakQty", TotalLeaks);
                                cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@Product_sno", o.ProductID);
                                vdm.Update(cmd);
                            }
                            else
                            {
                                cmd = new MySqlCommand("Update Leakages set VLeaks=@VLeaks,VarifyStatus=@VarifyStatus,VTripID=@VTripID  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VS");
                                //float ReturnQty = 0;
                                //float.TryParse(o.ReturnsQty, out ReturnQty);
                                //cmd.Parameters.Add("@Vreturns", ReturnQty);
                                double TotalLeaks = 0;
                                double.TryParse(o.LeaksQty, out TotalLeaks);
                                TotalLeaks = Math.Round(TotalLeaks, 2);
                                cmd.Parameters.Add("@VLeaks", TotalLeaks);
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@TripID", o.TripID);
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VarifyStatus", 'V');
                                cmd.Parameters.Add("@VS", 'P');
                                if (TotalLeaks != 0.0)
                                {
                                    vdm.Update(cmd);
                                }
                            }
                        }
                    }
                    string Msg = "Leaks Successfully Updated";
                    string response = GetJson(Msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetVerifyReturns(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    List<VarifyReturnLeak> GetVarifyReturnLeaklist = new List<VarifyReturnLeak>();
                    cmd = new MySqlCommand("SELECT  T1.Sno, T1.DispName, T2.TripID, T2.ReturnQty, T2.ProductID, T2.ProductName FROM  (SELECT tripdata.Sno, dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.sno = @dispatchsno) AND (tripdata.DEmpId = @DEmpID)) T1 INNER JOIN (SELECT  leakages.TripID, leakages.ReturnQty, leakages.ProductID, productsdata.ProductName FROM  leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyReturnStatus = @VarifyReturnStatus)) T2 ON T1.Sno = T2.TripID");
                    //cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.ReturnQty,  leakages.ProductID, productsdata.ProductName, dispatch.DispName  FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN leakages ON tripdata.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyReturnStatus = @VarifyReturnStatus) AND (dispatch.sno = @dispatchsno) AND (tripdata.DEmpID = @DEmpID)");
                        cmd.Parameters.Add("@dispatchsno", RouteSno);
                       cmd.Parameters.Add("@DEmpID", context.Session["PlantEmpId"].ToString());
                        cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                        DataTable dtVarifyReturns = vdm.SelectQuery(cmd).Tables[0];
                        if (dtVarifyReturns.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtVarifyReturns.Rows)
                            {
                                VarifyReturnLeak GetVarifyReturnLeak = new VarifyReturnLeak();
                                GetVarifyReturnLeak.Sno = i++.ToString();
                                GetVarifyReturnLeak.ProdId = dr["ProductID"].ToString();
                                GetVarifyReturnLeak.ProdName = dr["ProductName"].ToString();
                                float ReturnQty = 0;
                                float.TryParse(dr["ReturnQty"].ToString(), out ReturnQty);
                                GetVarifyReturnLeak.Returns = ReturnQty.ToString();
                                GetVarifyReturnLeak.Trip = dr["Sno"].ToString();
                                GetVarifyReturnLeak.EmpName = dr["DispName"].ToString();
                                if (ReturnQty != 0.0)
                                {
                                    GetVarifyReturnLeaklist.Add(GetVarifyReturnLeak);
                                }
                            }
                        }
                    //}
                    string response = GetJson(GetVarifyReturnLeaklist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetVerifyLeaks(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    List<VarifyReturnLeak> GetVarifyReturnLeaklist = new List<VarifyReturnLeak>();
                    cmd = new MySqlCommand("SELECT  T1.Tripdata_sno, T1.DispName, T2.TripID, T2.TotalLeaks, T2.ProductID, T2.ProductName ,T2.Sno FROM   (SELECT  triproutes.Tripdata_sno, dispatch.DispName FROM  dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID WHERE (dispatch.sno = @dispatchsno)) T1 INNER JOIN (SELECT tripdata.Sno, leakages.TripID, leakages.TotalLeaks, leakages.ProductID, productsdata.ProductName FROM  tripdata INNER JOIN leakages ON tripdata.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyStatus = @VarifyStatus) AND (tripdata.DEmpId = @DEmpID)) T2 ON T1.Tripdata_sno = T2.Sno");
                    //cmd = new MySqlCommand("SELECT tripdata.Sno, leakages.TotalLeaks, productsdata.ProductName, dispatch.DispName, leakages.ProductID  FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN leakages ON tripdata.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VarifyStatus = @VarifyStatus) AND (dispatch.sno = @dispatchsno) AND (tripdata.DEmpID = @DEmpID)");
                    cmd.Parameters.Add("@dispatchsno", RouteSno);
                    cmd.Parameters.Add("@DEmpID", context.Session["PlantEmpId"].ToString());
                    cmd.Parameters.Add("@VarifyStatus", 'P');
                    DataTable dtVarifyLeaks = vdm.SelectQuery(cmd).Tables[0];
                    if (dtVarifyLeaks.Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in dtVarifyLeaks.Rows)
                        {
                            VarifyReturnLeak GetVarifyReturnLeak = new VarifyReturnLeak();
                            GetVarifyReturnLeak.Sno = i++.ToString();
                            GetVarifyReturnLeak.ProdId = dr["ProductID"].ToString();
                            GetVarifyReturnLeak.ProdName = dr["ProductName"].ToString();
                            GetVarifyReturnLeak.Leaks = dr["TotalLeaks"].ToString();
                            GetVarifyReturnLeak.Trip = dr["Sno"].ToString();
                            GetVarifyReturnLeak.EmpName = dr["DispName"].ToString();
                            GetVarifyReturnLeaklist.Add(GetVarifyReturnLeak);
                        }
                    }
                    //}
                    string response = GetJson(GetVarifyReturnLeaklist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class VarifyReturnLeak
        {
            public string Sno { get; set; }
            public string ProdId { get; set; }
            public string ProdName { get; set; }
            public string Returns { get; set; }
            public string Leaks { get; set; }
            public string Trip { get; set; }
            public string EmpName { get; set; }
        }
        private void GetReturnLeakReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    List<ReturnLeakClass> ReturnLeaklist = new List<ReturnLeakClass>();
                    string LevelType = context.Session["LevelType"].ToString();
                    if (LevelType == "Dispatcher")
                    {
                        cmd = new MySqlCommand("SELECT ROUND(SUM(leakages.VLeaks), 2) AS VLeaks, ROUND(SUM(leakages.VReturns), 2) AS VReturns, productsdata.ProductName, leakages.ProductID,leakages.VarifyReturnStatus, leakages.VarifyStatus FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (leakages.VTripID = @VTripID) GROUP BY productsdata.ProductName, leakages.VTripID ORDER BY productsdata.sno");
                        cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                        DataTable dtPuffLeak = vdm.SelectQuery(cmd).Tables[0];
                        if (dtPuffLeak.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow drPufLeak in dtPuffLeak.Rows)
                            {
                                ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                GetReturnLeak.Sno = i++.ToString();
                                GetReturnLeak.ProdId = drPufLeak["ProductID"].ToString();
                                GetReturnLeak.ProdName = drPufLeak["ProductName"].ToString();
                                GetReturnLeak.Returns = drPufLeak["VReturns"].ToString();
                                GetReturnLeak.Leaks = drPufLeak["VLeaks"].ToString();
                                ReturnLeaklist.Add(GetReturnLeak);
                            }
                        }
                    }
                    else if (LevelType == "SODispatcher")
                    {
                        cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName,branchproducts.BranchQty, branchproducts.LeakQty FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) ");
                        cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                        DataTable dtAgentLeak = vdm.SelectQuery(cmd).Tables[0];
                        int i = 1;
                        foreach (DataRow drSubData in dtAgentLeak.Rows)
                        {
                            ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                            GetReturnLeak.Sno = i++.ToString();
                            GetReturnLeak.ProdId = drSubData["product_sno"].ToString();
                            GetReturnLeak.ProdName = drSubData["ProductName"].ToString();
                            double Leaks = 0;
                            double.TryParse(drSubData["LeakQty"].ToString(), out Leaks);
                            Leaks = Math.Round(Leaks, 2);
                            double Returns = 0;
                            double.TryParse(drSubData["BranchQty"].ToString(), out Returns);
                            Returns = Math.Round(Returns, 2);
                            GetReturnLeak.Returns = drSubData["BranchQty"].ToString();
                            GetReturnLeak.Leaks = Leaks.ToString();
                            if (Leaks != 0.0 || Returns != 0.0)
                            {
                                GetReturnLeak.SReturns = "0";
                                GetReturnLeak.SLeaks = "0";
                                ReturnLeaklist.Add(GetReturnLeak);
                            }
                        }
                    }
                    else
                    {
                        DataTable dtLeakProducts = new DataTable();
                        DataTable dtRouteProducts = new DataTable();
                        DataTable dtproductsdata = new DataTable();
                        if (context.Session["dtproductsdata"] == null)
                        {
                            cmd = new MySqlCommand("SELECT sno, ProductName FROM productsdata ORDER BY sno");
                            dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                        }
                        dtLeakProducts.Columns.Add("sno");
                        dtLeakProducts.Columns.Add("ProductName");
                        dtLeakProducts.Columns.Add("LeakQty");
                        dtLeakProducts.Columns.Add("DeliveryQty");
                        foreach (DataRow dr in dtproductsdata.Rows)
                        {
                            DataRow newRow = dtLeakProducts.NewRow();
                            newRow["sno"] = dr["sno"].ToString();
                            newRow["ProductName"] = dr["ProductName"].ToString();
                            newRow["LeakQty"] = "0";
                            newRow["DeliveryQty"] = "0";
                            dtLeakProducts.Rows.Add(newRow);
                        }
                        dtRouteProducts.Columns.Add("sno");
                        dtRouteProducts.Columns.Add("ProductName");
                        dtRouteProducts.Columns.Add("LeakQty");
                        dtRouteProducts.Columns.Add("DeliveryQty");
                        dtRouteProducts.Columns.Add("ShortQty");
                        dtRouteProducts.Columns.Add("FreeMilk");
                        foreach (DataRow dr in dtproductsdata.Rows)
                        {
                            DataRow newRow = dtRouteProducts.NewRow();
                            newRow["sno"] = dr["sno"].ToString();
                            newRow["ProductName"] = dr["ProductName"].ToString();
                            newRow["LeakQty"] = "0";
                            newRow["DeliveryQty"] = "0";
                            newRow["ShortQty"] = "0";
                            newRow["FreeMilk"] = "0";
                            dtRouteProducts.Rows.Add(newRow);
                        }
                        cmd = new MySqlCommand("SELECT indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty),2) AS LeakQty FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents_subtable.DTripId = @TripID)  GROUP BY productsdata.ProductName order by Product_sno");
                        cmd.Parameters.Add("@TripID", context.Session["TripID"].ToString());
                        DataTable dtAgentLeak = vdm.SelectQuery(cmd).Tables[0];
                        if (dtAgentLeak.Rows.Count > 0)
                        {
                            foreach (DataRow drAgent in dtAgentLeak.Rows)
                            {
                                foreach (DataRow drtotprod in dtLeakProducts.Rows)
                                {

                                    if (drAgent["Product_sno"].ToString() == drtotprod["sno"].ToString())
                                    {
                                        float ALeak = 0;
                                        float.TryParse(drAgent["LeakQty"].ToString(), out ALeak);
                                        float Rleak = 0;
                                        float.TryParse(drtotprod["LeakQty"].ToString(), out Rleak);
                                        float totalqty = ALeak + Rleak;
                                        float ADel = 0;
                                        float.TryParse(drAgent["DeliveryQty"].ToString(), out ADel);
                                        float RDel = 0;
                                        float.TryParse(drtotprod["DeliveryQty"].ToString(), out RDel);
                                        float totDel = ADel + RDel;
                                        drtotprod["LeakQty"] = totalqty;
                                        drtotprod["DeliveryQty"] = totDel;
                                    }
                                }
                            }
                        }
                        DataTable dtRouteLeaks = new DataTable();
                        cmd = new MySqlCommand("select LeakQty,ShortQty,FreeMilk,ProductID from Leakages where TripId=@TripId and VarifyStatus is NULL order by ProductID");
                        cmd.Parameters.Add("@TripId", context.Session["TripID"].ToString());
                        dtRouteLeaks = vdm.SelectQuery(cmd).Tables[0];
                        if (dtRouteLeaks.Rows.Count > 0)
                        {
                            foreach (DataRow drAgent in dtRouteLeaks.Rows)
                            {
                                foreach (DataRow drtotprod in dtRouteProducts.Rows)
                                {

                                    if (drAgent["ProductID"].ToString() == drtotprod["sno"].ToString())
                                    {
                                        float ALeak = 0;
                                        float.TryParse(drAgent["LeakQty"].ToString(), out ALeak);
                                        float Rleak = 0;
                                        float.TryParse(drtotprod["LeakQty"].ToString(), out Rleak);
                                        float totalqty = ALeak + Rleak;
                                        float AShort = 0;
                                        float.TryParse(drAgent["ShortQty"].ToString(), out AShort);
                                        float RShort = 0;
                                        float.TryParse(drtotprod["ShortQty"].ToString(), out RShort);
                                        float totalRShort = AShort + RShort;
                                        float AFreeMilk = 0;
                                        float.TryParse(drAgent["FreeMilk"].ToString(), out AFreeMilk);
                                        float RAFreeMilk = 0;
                                        float.TryParse(drtotprod["FreeMilk"].ToString(), out RAFreeMilk);
                                        float totalRAFreeMilk = AFreeMilk + RAFreeMilk;
                                        drtotprod["LeakQty"] = totalqty;
                                        drtotprod["ShortQty"] = totalRShort;
                                        drtotprod["FreeMilk"] = totalRAFreeMilk;
                                    }
                                }
                            }
                        }
                        int i = 1;
                        if (dtRouteLeaks.Rows.Count > 0)
                        {
                            foreach (DataRow drAgentLeak in dtLeakProducts.Rows)
                            {
                                foreach (DataRow drRouteLeaks in dtRouteProducts.Rows)
                                {
                                    if (drAgentLeak["sno"].ToString() == drRouteLeaks["sno"].ToString())
                                    {
                                        float DelQty = 0;
                                        float.TryParse(drAgentLeak["DeliveryQty"].ToString(), out DelQty);
                                        float AgentLeak = 0;
                                        float.TryParse(drAgentLeak["LeakQty"].ToString(), out AgentLeak);
                                        float RouteLeak = 0;
                                        float.TryParse(drRouteLeaks["LeakQty"].ToString(), out RouteLeak);
                                        float FreeMilk = 0;
                                        float.TryParse(drRouteLeaks["FreeMilk"].ToString(), out FreeMilk);
                                        float Short = 0;
                                        float.TryParse(drRouteLeaks["ShortQty"].ToString(), out Short);
                                        float TotalLeaks = AgentLeak + RouteLeak + FreeMilk + Short + DelQty;
                                        cmd = new MySqlCommand("SELECT tripsubdata.Qty AS DispQty, productsdata.ProductName, productsdata.sno FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @Tripid) AND (productsdata.sno = @ProductID) ");
                                        cmd.Parameters.Add("@Tripid", context.Session["TripID"].ToString());
                                        cmd.Parameters.Add("@ProductID", drRouteLeaks["sno"].ToString());
                                        DataTable dtSubdata = vdm.SelectQuery(cmd).Tables[0];
                                        foreach (DataRow drSubData in dtSubdata.Rows)
                                        {
                                            float SubQty = 0;
                                            float.TryParse(drSubData["DispQty"].ToString(), out SubQty);
                                            float Return = 0;
                                            Return = SubQty - TotalLeaks;
                                            ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                            GetReturnLeak.Sno = i++.ToString();
                                            GetReturnLeak.ProdId = drSubData["sno"].ToString();
                                            GetReturnLeak.ProdName = drSubData["ProductName"].ToString();
                                            GetReturnLeak.Returns = Return.ToString();
                                            GetReturnLeak.SReturns = Return.ToString();
                                            float Leaks = 0;
                                            Leaks = AgentLeak + RouteLeak;
                                            GetReturnLeak.Leaks = Leaks.ToString();
                                            GetReturnLeak.SLeaks = Leaks.ToString();
                                            if (Leaks != 0.0 || Return != 0.0)
                                            {
                                                ReturnLeaklist.Add(GetReturnLeak);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow drAgentLeak in dtAgentLeak.Rows)
                            {
                                cmd = new MySqlCommand("SELECT tripsubdata.Qty AS DispQty, productsdata.ProductName, productsdata.sno FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @Tripid) AND (productsdata.sno = @ProductID) ");
                                cmd.Parameters.Add("@Tripid", context.Session["TripID"].ToString());
                                cmd.Parameters.Add("@ProductID", drAgentLeak["Product_sno"].ToString());
                                DataTable dtSubdata = vdm.SelectQuery(cmd).Tables[0];
                                float DelQty = 0;
                                float.TryParse(drAgentLeak["DeliveryQty"].ToString(), out DelQty);
                                float AgentLeak = 0;
                                float.TryParse(drAgentLeak["LeakQty"].ToString(), out AgentLeak);
                                float RouteLeak = 0;
                                float TotalLeaks = AgentLeak + RouteLeak + DelQty;
                                foreach (DataRow drSubData in dtSubdata.Rows)
                                {
                                    float SubQty = 0;
                                    float.TryParse(drSubData["DispQty"].ToString(), out SubQty);
                                    float Return = 0;
                                    Return = SubQty - TotalLeaks;
                                    ReturnLeakClass GetReturnLeak = new ReturnLeakClass();
                                    GetReturnLeak.Sno = i++.ToString();
                                    GetReturnLeak.ProdId = drSubData["sno"].ToString();
                                    GetReturnLeak.ProdName = drSubData["ProductName"].ToString();
                                    GetReturnLeak.Returns = Return.ToString();
                                    GetReturnLeak.SReturns = Return.ToString();
                                    float Leaks = 0;
                                    Leaks = AgentLeak + RouteLeak;
                                    GetReturnLeak.SLeaks = Leaks.ToString();
                                    GetReturnLeak.Leaks = Leaks.ToString();
                                    if (Leaks != 0.0 || Return != 0.0)
                                    {
                                        ReturnLeaklist.Add(GetReturnLeak);
                                    }
                                }
                            }
                        }
                    }
                    string response = GetJson(ReturnLeaklist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class ReturnLeakClass
        {
            public string Sno { get; set; }
            public string ProdId { get; set; }
            public string ProdName { get; set; }
            public string Returns { get; set; }
            public string Leaks { get; set; }
            public string SReturns { get; set; }
            public string SLeaks { get; set; }
        }
        private void DeliverReportclick(HttpContext context)
        {
            try
            {
                DataTable Report = new DataTable();
                vdm = new VehicleDBMgr();
                string IndentDate = context.Session["I_Date"].ToString();
                string RouteId = context.Session["RouteId"].ToString();
                string Permissions = context.Session["Permissions"].ToString();
                //if (Permissions == "")
                //{
                //    IndentDate = context.Session["I_Date"].ToString();
                //    RouteId = context.Session["RouteId"].ToString();
                //}
                //else
                //{
                //    IndentDate = context.Session["I_Date"].ToString();
                //    RouteId = context.Session["RouteId"].ToString();
                //}

                DateTime dtDispDate = Convert.ToDateTime(IndentDate);
                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty), 2) AS LeakQty, indents_subtable.UnitCost, indents.IndentNo, indents.Branch_id, ROUND(SUM(indents_subtable.UnitCost * indents_subtable.DeliveryQty), 2) AS Total FROM  dispatch RIGHT OUTER JOIN branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno ON dispatch.Route_id = branchroutes.Sno LEFT OUTER JOIN indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno ON branchdata.sno = indents.Branch_id WHERE (indents.I_date >= @starttime) AND (indents.I_date < @endtime) AND (dispatch.sno = @dispatchSno) GROUP BY productsdata.ProductName");
                // cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty),2) AS unitQty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.Sno,ROUND(SUM(indents_subtable.DeliveryQty),2) AS DeliveryQty, ROUND(SUM(indents_subtable.LeakQty),2) AS LeakQty, indents_subtable.UnitCost, indents.IndentNo, indents.Branch_id,ROUND(SUM(indents_subtable.UnitCost * indents_subtable.DeliveryQty),2) AS Total FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo RIGHT OUTER JOIN  productsdata ON indents_subtable.Product_sno = productsdata.sno LEFT OUTER JOIN branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno ON indents.Branch_id = branchdata.sno WHERE(branchroutes.Sno = @TripID) AND (indents.I_date >= @starttime) AND (indents.I_date < @endtime) GROUP BY productsdata.ProductName");
                cmd.Parameters.Add("@dispatchSno", RouteId);
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                DataTable dtble = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.Branchid, collections.AmountPaid, indents_subtable.DeliveryQty * indents_subtable.UnitCost AS totalamount, collections.PaidDate, indents_subtable.D_date FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON indents.Branch_id = collections.Branchid INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN dispatch ON branchroutes.Sno = dispatch.Route_id WHERE (indents.I_date > @starttime) AND (indents.I_date < @endtime) AND (collections.PaidDate >= @Paidstime) AND (collections.PaidDate < @Paidetime) AND (dispatch.sno = @dispatchSno)GROUP BY branchdata.BranchName, indents_subtable.DeliveryQty, indents_subtable.UnitCost, collections.PaidDate, indents_subtable.D_date");
                // cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.Branchid, collections.AmountPaid,indents_subtable.DeliveryQty * indents_subtable.UnitCost AS totalamount, collections.PaidDate, indents_subtable.D_date FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN  branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON indents.Branch_id = collections.Branchid INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (branchroutes.Sno = @TripID) AND (indents.I_date > @starttime) AND (indents.I_date < @endtime) AND (collections.PaidDate >= @Paidstime) and (collections.PaidDate < @Paidetime)GROUP BY branchdata.BranchName, indents_subtable.DeliveryQty, indents_subtable.UnitCost, collections.PaidDate, indents_subtable.D_date");
                cmd.Parameters.Add("@dispatchSno", RouteId);
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                cmd.Parameters.Add("@Paidstime", DateConverter.GetLowDate(dtDispDate.AddDays(1)));
                cmd.Parameters.Add("@Paidetime", DateConverter.GetHighDate(dtDispDate.AddDays(1)));
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT tripsubdata.Tripdata_sno, tripsubdata.Qty as DispQty, productsdata.ProductName,productsdata.sno FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN triproutes ON triproutes.Tripdata_sno = tripsubdata.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripdata.I_Date BETWEEN @starttime AND @endtime) AND (dispatch.sno = @dispatchsno)");
                cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(dtDispDate));
                cmd.Parameters.Add("@dispatchSno", RouteId);
                DataTable dtSubData = vdm.SelectQuery(cmd).Tables[0];
                string Sno = dtSubData.Rows[0]["Tripdata_sno"].ToString();
                DataTable dtLeakages = new DataTable();
                cmd = new MySqlCommand("select LeakQty,ShortQty,FreeMilk,ProductID from Leakages where TripId=@TripId Group By ProductID  order by ProductID");
                cmd.Parameters.Add("@TripId", Sno);
                dtLeakages = vdm.SelectQuery(cmd).Tables[0];
                dtble.DefaultView.Sort = "Product_sno ASC";
                dtble = dtble.DefaultView.ToTable(true);
                if (dtble.Rows.Count > 0)
                {

                    Report = new DataTable();
                    //Report.
                    Report.Columns.Add("Variety");
                    Report.Columns.Add("Qty");
                    Report.Columns.Add("DispQty");
                    Report.Columns.Add("ReturnQty");
                    Report.Columns.Add("Leakage");
                    Report.Columns.Add("Short");
                    Report.Columns.Add("FreeMilk");
                    Report.Columns.Add("Sales");
                    Report.Columns.Add("Sales Value");
                    Report.Columns.Add("Agent Name");
                    Report.Columns.Add("Due Amount");
                    Report.Columns.Add("Amount");
                    //Report.Columns.Add("Denomin");
                    double totalqty = 0;
                    double Leakqty = 0;
                    double tDispqty = 0;
                    double tReturnqty = 0;
                    double delqty = 0;
                    double TotAmount = 0;
                    foreach (DataRow branch in dtble.Rows)
                    {
                        DataRow newrow = Report.NewRow();
                        newrow["Variety"] = branch["ProductName"].ToString();
                        newrow["Qty"] = branch["unitQty"].ToString();
                        float DispQty = 0;
                        float ReturnQty = 0;
                        foreach (DataRow drSubData in dtSubData.Rows)
                        {
                            if (branch["Product_sno"].ToString() == drSubData["sno"].ToString())
                            {
                                newrow["DispQty"] = drSubData["DispQty"].ToString();
                                float.TryParse(drSubData["DispQty"].ToString(), out DispQty);
                            }
                        }
                        float Leaks = 0;
                        float Totqty = 0;
                        if (dtLeakages.Rows.Count > 0)
                        {

                            string ProductID = branch["Product_sno"].ToString();
                            DataRow[] drleak = dtLeakages.Select("ProductID = '" + ProductID + "'");
                            if (drleak.Length != 0)
                            {
                                for (int i = 0; i < drleak.Length; i++)
                                {
                                    if (branch["Product_sno"].ToString() == drleak[i][3].ToString())
                                    {
                                        float Ileak = 0;
                                        float.TryParse(branch["LeakQty"].ToString(), out Ileak);
                                        float Rleak = 0;
                                        float.TryParse(drleak[i][0].ToString(), out Rleak);
                                        Leaks = Ileak + Rleak;
                                        newrow["Leakage"] = Math.Round(Leaks, 2);
                                        float ShortQty = 0;
                                        float.TryParse(drleak[i][1].ToString(), out ShortQty);
                                        newrow["Short"] = Math.Round(ShortQty, 2);
                                        float FreeMilk = 0;
                                        float.TryParse(drleak[i][2].ToString(), out FreeMilk);
                                        newrow["FreeMilk"] = Math.Round(FreeMilk, 2);
                                        float DeliveryQty = 0;
                                        float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                        Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                        ReturnQty = DispQty - Totqty;
                                        newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                    }
                                    else
                                    {
                                        newrow["Leakage"] = branch["LeakQty"].ToString();
                                        float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                                        float DeliveryQty = 0;
                                        float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                        float ShortQty = 0;
                                        newrow["Short"] = ShortQty;
                                        float FreeMilk = 0;
                                        newrow["FreeMilk"] = FreeMilk;
                                        Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                        ReturnQty = DispQty - Totqty;
                                        newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                    }
                                    tReturnqty += Math.Round(ReturnQty, 2); ;
                                    tDispqty += DispQty;
                                    Leakqty += Leaks;
                                }
                            }
                            else
                            {
                                newrow["Leakage"] = branch["LeakQty"].ToString();
                                float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                                float DeliveryQty = 0;
                                float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                                float ShortQty = 0;
                                newrow["Short"] = ShortQty;
                                float FreeMilk = 0;
                                newrow["FreeMilk"] = FreeMilk;
                                Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                                ReturnQty = DispQty - Totqty;
                                newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                                tReturnqty += Math.Round(ReturnQty, 2); ;
                                tDispqty += DispQty;
                                Leakqty += Leaks;
                            }
                        }
                        else
                        {
                            newrow["Leakage"] = branch["LeakQty"].ToString();
                            float.TryParse(branch["LeakQty"].ToString(), out Leaks);
                            float DeliveryQty = 0;
                            float.TryParse(branch["DeliveryQty"].ToString(), out DeliveryQty);
                            float ShortQty = 0;
                            newrow["Short"] = ShortQty;
                            float FreeMilk = 0;
                            newrow["FreeMilk"] = FreeMilk;
                            Totqty = Leaks + DeliveryQty + FreeMilk + ShortQty;
                            ReturnQty = DispQty - Totqty;
                            newrow["ReturnQty"] = Math.Round(ReturnQty, 2);
                            tReturnqty += Math.Round(ReturnQty, 2); ;
                            tDispqty += DispQty;
                            Leakqty += Leaks;
                        }
                        newrow["Sales"] = branch["DeliveryQty"].ToString();
                        //float LeakQty=0;
                        //float.TryParse(branch["LeakQty"].ToString(), out LeakQty);

                        newrow["Sales Value"] = branch["Total"].ToString();
                        double qtyvalue = 0;
                        double Leakqtyvalue = 0;
                        double delqtyvalue = 0;
                        double TotAmountvalue = 0;
                        double.TryParse(branch["unitQty"].ToString(), out qtyvalue);
                        totalqty += Math.Round(qtyvalue, 2);
                        //double.TryParse(branch["LeakQty"].ToString(), out Leakqtyvalue);
                        //Leakqty += Leakqtyvalue;
                        double.TryParse(branch["DeliveryQty"].ToString(), out delqtyvalue);
                        delqty += Math.Round(delqtyvalue, 2);
                        double.TryParse(branch["Total"].ToString(), out TotAmountvalue);
                        TotAmount += Math.Round(TotAmountvalue, 2);
                        //newrow["Denomin"] = "100";
                        Report.Rows.Add(newrow);
                    }
                    List<DeliveryClass> DeliveryList = new List<DeliveryClass>();
                    foreach (DataRow dr in Report.Rows)
                    {
                        DeliveryClass GetDQty = new DeliveryClass();
                        GetDQty.Variety = dr["Variety"].ToString();
                        GetDQty.Qty = dr["Qty"].ToString();
                        GetDQty.DispQty = dr["DispQty"].ToString();
                        GetDQty.ReturnQty = dr["ReturnQty"].ToString();
                        GetDQty.Shorts = dr["Short"].ToString();
                        GetDQty.Free = dr["FreeMilk"].ToString();
                        GetDQty.LeakQty = dr["Leakage"].ToString();
                        GetDQty.Sales = dr["Sales"].ToString();
                        DeliveryList.Add(GetDQty);
                    }
                    string errresponse = GetJson(DeliveryList);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        class DeliveryClass
        {
            public string Variety { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
            public string ReturnQty { get; set; }
            public string Shorts { get; set; }
            public string LeakQty { get; set; }
            public string Free { get; set; }
            public string Sales { get; set; }
        }
        private void btnInventoryVerifySaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    foreach (InvDatails o in obj.InvDatails)
                    {
                        if (o.SNo != null)
                        {
                            string Permissions = context.Session["Permissions"].ToString();
                            if (Permissions == "SODispatcher")
                            {
                                cmd = new MySqlCommand("Update invtransactions12 set VarifyStatus=@VarifyStatus,VTripID=@VTripID,VQty=@VQty  where B_Inv_Sno =@B_Inv_Sno and FromTran=@From and VarifyStatus=@VStatus");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@From", o.TripID);
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VarifyStatus", "V");
                                cmd.Parameters.Add("@VQty", o.Qty);
                                cmd.Parameters.Add("@VStatus", "p");
                                vdm.Update(cmd);
                                //cmd = new MySqlCommand("Update invtransactions set VarificationStatus=@VarificationStatus,  VTripID=@VTripID where B_Inv_Sno=@B_Inv_Sno and  tripId=@tripId and VarificationStatus=@PStatus");
                                //cmd.Parameters.Add("@VarificationStatus", "V");
                                //cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                //cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                //cmd.Parameters.Add("@tripId", o.TripID);
                                //cmd.Parameters.Add("@PStatus", "P");
                                //vdm.Update(cmd);
                                cmd = new MySqlCommand("Update inventory_monitor Set Qty=Qty+@Qty where BranchId=@BranchId and Inv_Sno=@Inv_Sno");
                                cmd.Parameters.Add("@Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                vdm.Update(cmd);
                            }
                            else
                            {
                                DataTable dtInventory = new DataTable();
                                cmd = new MySqlCommand("Update invtransactions12 set VarifyStatus=@VarifyStatus,VTripID=@VTripID,VempId=@VempId,VQTy=@VQTy  where B_Inv_Sno =@B_Inv_Sno and FromTran=@From and VarifyStatus=@VStatus");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@From", o.TripID);
                                cmd.Parameters.Add("@VempId", context.Session["PlantEmpId"].ToString());
                                cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                cmd.Parameters.Add("@VarifyStatus", "V");
                                cmd.Parameters.Add("@VQTy", o.Qty);
                                cmd.Parameters.Add("@VStatus", "p");
                                vdm.Update(cmd);
                                //cmd = new MySqlCommand("Update invtransactions set VarificationStatus=@VarificationStatus,VQty=@VQty,AempID=@AempID,VTripID=@VTripID where B_Inv_Sno=@B_Inv_Sno and  tripId=@tripId and VarificationStatus=@PStatus");
                                //cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                //cmd.Parameters.Add("@VarificationStatus", "V");
                                //cmd.Parameters.Add("@PStatus", "P");
                                //cmd.Parameters.Add("@VQty", o.Qty);
                                //cmd.Parameters.Add("@AempID", context.Session["PlantEmpId"].ToString());
                                //cmd.Parameters.Add("@tripId", o.TripID);
                                //cmd.Parameters.Add("@VTripID", context.Session["PlantDispSno"].ToString());
                                //vdm.Update(cmd);

                                string LevelType = context.Session["LevelType"].ToString();
                                if (dtInventory.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtInventory.Rows)
                                    {
                                        string PInvSno = dr["B_Inv_Sno"].ToString();
                                        if (o.SNo == PInvSno)
                                        {
                                            int PInvQty = 0;
                                            int.TryParse(dr["Qty"].ToString(), out PInvQty);
                                            int InvQty = 0;
                                            int.TryParse(o.Qty, out InvQty);
                                            float TQty = InvQty - PInvQty;
                                            if (TQty >= 1)
                                            {
                                                cmd = new MySqlCommand("Update tripinvdata set Status=@Status,Remaining=Remaining-@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                cmd.Parameters.Add("@Tripdata_sno", o.TripID);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Status", 'V');
                                                vdm.Update(cmd);
                                                cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                if (vdm.Update(cmd) == 0)
                                                {
                                                    cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                                    cmd.Parameters.Add("@Invid", o.SNo);
                                                    int Qty = 0;
                                                    cmd.Parameters.Add("@Qty", Qty);
                                                    cmd.Parameters.Add("@Remaining", TQty);
                                                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                    vdm.insert(cmd);
                                                }
                                            }
                                            else
                                            {
                                                TQty = Math.Abs(TQty);
                                                cmd = new MySqlCommand("Update tripinvdata set Status=@Status,Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                cmd.Parameters.Add("@Tripdata_sno", o.TripID);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Status", 'V');
                                                vdm.Update(cmd);
                                                cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining-@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                                cmd.Parameters.Add("@Invid", o.SNo);
                                                cmd.Parameters.Add("@Remaining", TQty);
                                                cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                if (vdm.Update(cmd) == 0)
                                                {
                                                    cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                                    cmd.Parameters.Add("@Invid", o.SNo);
                                                    int Qty = 0;
                                                    cmd.Parameters.Add("@Qty", Qty);
                                                    cmd.Parameters.Add("@Remaining", TQty);
                                                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                                    vdm.insert(cmd);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining+@Remaining where Invid=@Invid and  Tripdata_sno=@Tripdata_sno");
                                    cmd.Parameters.Add("@Invid", o.SNo);
                                    cmd.Parameters.Add("@Remaining", o.Qty);
                                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                        cmd.Parameters.Add("@Invid", o.SNo);
                                        int Qty = 0;
                                        cmd.Parameters.Add("@Qty", Qty);
                                        cmd.Parameters.Add("@Remaining", o.Qty);
                                        cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                        }
                    }
                    string msg = "Data Saved Successfully";
                    string msgresponse = GetJson(msg);
                    context.Response.Write(msgresponse);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string msgresponse = GetJson(msg);
                context.Response.Write(msgresponse);
            }
        }
        private void GetVerifyInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<DispatchInventory> Inventorylist = new List<DispatchInventory>();
                if (context.Session["CsoNo"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteSno = context.Request["RouteSno"];
                    cmd = new MySqlCommand("SELECT  T1.DispName, T2.InvName, T2.B_inv_sno, T2.TripID, T2.Expr1, T2.Qty, T2.Sno FROM (SELECT  triproutes.Tripdata_sno, dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID WHERE (dispatch.sno = @dispatchsno)) T1 INNER JOIN (SELECT  invmaster.InvName, invtransactions12.B_inv_sno, invtransactions12.FromTran AS TripID, invmaster.InvName AS Expr1, invtransactions12.Qty, tripdata.Sno FROM  tripdata INNER JOIN invtransactions12 ON tripdata.Sno = invtransactions12.FromTran INNER JOIN invmaster ON invtransactions12.B_inv_sno = invmaster.sno WHERE (invtransactions12.VarifyStatus = @VarificationStatus) AND (invtransactions12.TransType = @TransType)) T2 ON T1.Tripdata_sno = T2.Sno");
                    
                    //cmd = new MySqlCommand("SELECT invmaster.InvName, invtransactions12.B_inv_sno, invtransactions12.FromTran AS TripID, invmaster.InvName AS Expr1, invtransactions12.Qty, tripdata.Sno, dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN invtransactions12 ON tripdata.Sno = invtransactions12.FromTran INNER JOIN invmaster ON invtransactions12.B_inv_sno = invmaster.sno WHERE (dispatch.sno = @dispatchsno) AND (invtransactions12.VarifyStatus = @VarificationStatus) AND (invtransactions12.TransType = @TransType) GROUP BY invmaster.InvName");

                        cmd.Parameters.Add("@dispatchsno", RouteSno);
                        cmd.Parameters.Add("@DEmpID", context.Session["PlantEmpId"].ToString());

                        cmd.Parameters.Add("@TransType", "2");
                        cmd.Parameters.Add("@VarificationStatus", "P");
                        DataTable DtReport = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["dtVerifyInventory"] = DtReport;
                        if (DtReport.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in DtReport.Rows)
                            {
                                DispatchInventory GetInventory = new DispatchInventory();
                                GetInventory.Sno = i++.ToString();
                                GetInventory.InvName = dr["InvName"].ToString();
                                GetInventory.InvSno = dr["B_Inv_Sno"].ToString();
                                GetInventory.EmpName = dr["DispName"].ToString();
                                GetInventory.Invqty = dr["Qty"].ToString();
                                GetInventory.TripId = dr["TripID"].ToString();
                                Inventorylist.Add(GetInventory);
                            }
                        }
                    //}
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class DispatchInventory
        {
            public string Sno { get; set; }
            public string InvSno { get; set; }
            public string InvName { get; set; }
            public string EmpName { get; set; }
            public string Invqty { get; set; }
            public string TripId { get; set; }
        }
        private void btnReportingInventoryclick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    string LevelType = context.Session["LevelType"].ToString();
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    string PlantTripSno = "";
                    string BranchId = "";
                    string status = "";
                    if (LevelType == "SODispatcher")
                    {
                        string DispSno = obj.DispSno;
                        cmd = new MySqlCommand("SELECT tripdata.Sno, dispatch.BranchID, dispatch_sub.IndentType FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (tripdata.SOTransfer=@SOTransfer) and (dispatch.sno = @DispSno)  and (tripdata.Permissions<>'O') group by dispatch.sno");
                        cmd.Parameters.Add("@DispSno", DispSno);
                        cmd.Parameters.Add("@SOTransfer", "L");
                        DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                        PlantTripSno = dtBranch.Rows[0]["Sno"].ToString();
                        BranchId = dtBranch.Rows[0]["BranchID"].ToString();
                        cmd = new MySqlCommand("SELECT Sno, Status FROM tripdata WHERE (Sno = @tripid)");
                        cmd.Parameters.Add("@tripid", PlantTripSno);
                        DataTable dttripstatus = vdm.SelectQuery(cmd).Tables[0];
                        status = dttripstatus.Rows[0]["Status"].ToString();
                        if (status == "V")
                        {
                            cmd = new MySqlCommand("update tripdata set SOTransfer=@SOTransfer,ReturnDCTime=@ReturnDCTime where Sno=@TripSno");
                            cmd.Parameters.Add("@TripSno", PlantTripSno);
                            cmd.Parameters.Add("@ReturnDCTime", ServerDateCurrentdate);
                            // cmd.Parameters.Add("@Status", "P");
                            cmd.Parameters.Add("@SOTransfer", "U");
                            vdm.Update(cmd);
                        }
                        else
                        {
                            cmd = new MySqlCommand("update tripdata set Status=@Status,SOTransfer=@SOTransfer,ReturnDCTime=@ReturnDCTime where Sno=@TripSno");
                            cmd.Parameters.Add("@TripSno", PlantTripSno);
                            cmd.Parameters.Add("@ReturnDCTime", ServerDateCurrentdate);
                            cmd.Parameters.Add("@Status", "P");
                            cmd.Parameters.Add("@SOTransfer", "U");
                            vdm.Update(cmd);
                        }

                    }
                    foreach (InvDatails o in obj.InvDatails)
                    {
                        if (o.SNo != null)
                        {
                            if (LevelType == "SODispatcher")
                            {
                                cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@TransType", "3");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", PlantTripSno);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@TransType", "3");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", PlantTripSno);
                                    cmd.Parameters.Add("@VarifyStatus", "P");
                                    if (o.Qty != "0")
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                                cmd = new MySqlCommand("Update inventory_monitor set Qty=Qty-@Qty where  Inv_sno=@Inv_sno and BranchId=@BranchId");
                                cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@Inv_sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                vdm.Update(cmd);
                                cmd = new MySqlCommand("update tripinvdata set Remaining=@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                int Remaining = 0;
                                int.TryParse(o.Qty, out Remaining);
                                cmd.Parameters.Add("@Remaining", Remaining);
                                cmd.Parameters.Add("@invId", o.SNo);
                                cmd.Parameters.Add("@TripID", PlantTripSno);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  tripinvdata (Remaining,Invid,Tripdata_sno,Qty) values(@Remaining,@Invid,@Tripdata_sno,@Qty)");
                                    cmd.Parameters.Add("@Invid", o.SNo);
                                    int Qty = 0;
                                    cmd.Parameters.Add("@Qty", Qty);
                                    cmd.Parameters.Add("@Remaining", Remaining);
                                    cmd.Parameters.Add("@Tripdata_sno", PlantTripSno);
                                    vdm.insert(cmd);
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                cmd.Parameters.Add("@Qty", o.Qty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@TransType", "2");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType,VarifyStatus) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType,@VarifyStatus)");
                                    cmd.Parameters.Add("@B_Inv_Sno", o.SNo);
                                    cmd.Parameters.Add("@Qty", o.Qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@TransType", "2");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", context.Session["BranchSno"].ToString());
                                    cmd.Parameters.Add("@VarifyStatus", "P");
                                    if (o.Qty != "0")
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                        }
                    }
                    //DateTime ServerDateCurrentdate = Convert.ToDateTime(indentdate);
                    DateTime dtapril = new DateTime();
                    DateTime dtmarch = new DateTime();
                    int currentyear = ServerDateCurrentdate.Year;
                    int nextyear = ServerDateCurrentdate.Year + 1;
                    if (ServerDateCurrentdate.Month > 3)
                    {
                        string apr = "4/1/" + currentyear;
                        dtapril = DateTime.Parse(apr);
                        string march = "3/31/" + nextyear;
                        dtmarch = DateTime.Parse(march);
                    }
                    if (ServerDateCurrentdate.Month <= 3)
                    {
                        string apr = "4/1/" + (currentyear - 1);
                        dtapril = DateTime.Parse(apr);
                        string march = "3/31/" + (nextyear - 1);
                        dtmarch = DateTime.Parse(march);
                    }
                    string tostate = "";
                    string branchid = "";
                    string companycode = "";
                    string statecode = "";
                    cmd = new MySqlCommand("SELECT  branchdata.sno, branchdata.BranchName,branchdata.companycode, branchdata.SalesType, branchdata.Lat, branchdata.Lng, branchdata.Radius, statemastar.gststatecode, branchdata.stateid FROM branchdata INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (branchdata.sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    DataTable dtEmpID = vdm.SelectQuery(cmd).Tables[0];
                    if (dtEmpID.Rows.Count > 0)
                    {
                        tostate = dtEmpID.Rows[0]["stateid"].ToString();
                        branchid = dtEmpID.Rows[0]["sno"].ToString();
                        companycode = dtEmpID.Rows[0]["companycode"].ToString();
                        statecode = dtEmpID.Rows[0]["gststatecode"].ToString();
                    }
                    foreach (RouteLeakdetails o in obj.RouteLeakdetails)
                    {
                        //cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (stateid = @stateid) AND (companycode=@companycode) AND (IndDate BETWEEN @d1 AND @d2)");
                        //cmd.Parameters.Add("@stateid", statecode);
                        //cmd.Parameters.Add("@companycode", companycode);
                        //cmd.Parameters.Add("@d1", GetLowDate(dtapril));
                        //cmd.Parameters.Add("@d2", GetHighDate(dtmarch));
                        //DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                        string invno = "0";
                        //cmd = new MySqlCommand("Insert Into Agentdc (BranchId,IndDate,agentdcno,soid,stateid,companycode,moduleid) Values(@BranchId,@IndDate,@agentdcno,@soid,@stateid,@companycode,@moduleid)");
                        //cmd.Parameters.Add("@BranchId", obj.DispSno);
                        //cmd.Parameters.Add("@IndDate", ServerDateCurrentdate);
                        //cmd.Parameters.Add("@agentdcno", invno);
                        //cmd.Parameters.Add("@soid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@stateid", statecode);
                        //cmd.Parameters.Add("@companycode", companycode);
                        //cmd.Parameters.Add("@moduleid", "4");// Module 4 is Credit Note (Ex...Leaks)
                        //vdm.insert(cmd);
                        if (LevelType == "SODispatcher")
                        {
                            cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty-@BranchQty,LeakQty=LeakQty-@LeakQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                            cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                            double ReturnQty = 0;
                            double.TryParse(o.ReturnsQty, out ReturnQty);
                            ReturnQty = Math.Round(ReturnQty, 2);
                            double LeaksQty = 0;
                            double.TryParse(o.LeaksQty, out LeaksQty);
                            LeaksQty = Math.Round(LeaksQty, 2);
                            cmd.Parameters.Add("@Product_sno", o.ProductID);
                            cmd.Parameters.Add("@BranchQty", ReturnQty);
                            cmd.Parameters.Add("@LeakQty", LeaksQty);
                            vdm.Update(cmd);
                            cmd = new MySqlCommand("Update Leakages set ReturnQty=@ReturnQty,TotalLeaks=@TotalLeaks,EntryDate=@EntryDate  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VarifyStatus and VarifyReturnStatus=@VarifyReturnStatus");
                            cmd.Parameters.Add("@ReturnQty", ReturnQty);
                            double TotalLeaks = 0;
                            double.TryParse(o.LeaksQty, out TotalLeaks);
                            TotalLeaks = Math.Round(TotalLeaks, 2);
                            cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                            cmd.Parameters.Add("@TripID", PlantTripSno);
                            if (status == "V")
                            {
                                cmd.Parameters.Add("@VarifyStatus", 'V');
                                cmd.Parameters.Add("@VarifyReturnStatus", 'V');
                            }
                            else
                            {
                                cmd.Parameters.Add("@VarifyStatus", 'P');
                                cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                            }

                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  Leakages(ReturnQty,TotalLeaks,ProductID,TripID,VarifyStatus,EntryDate,VarifyReturnStatus,invoiceno) Values (@ReturnQty,@TotalLeaks,@ProductID,@TripID,@VarifyStatus,@EntryDate,@VarifyReturnStatus,@invoiceno)");
                                cmd.Parameters.Add("@ReturnQty", ReturnQty);
                                cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                                cmd.Parameters.Add("@TripID", PlantTripSno);
                                cmd.Parameters.Add("@VarifyStatus", 'P');
                                cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                                cmd.Parameters.Add("@invoiceno", invno);
                                vdm.insert(cmd);
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("Update Leakages set ReturnQty=@ReturnQty,TotalLeaks=@TotalLeaks,EntryDate=@EntryDate  where ProductID=@ProductID and TripID=@TripID and VarifyStatus=@VarifyStatus and VarifyReturnStatus=@VarifyReturnStatus");
                            double ReturnQty = 0;
                            double.TryParse(o.ReturnsQty, out ReturnQty);
                            ReturnQty = Math.Round(ReturnQty, 2);
                            cmd.Parameters.Add("@ReturnQty", ReturnQty);
                            double TotalLeaks = 0;
                            double.TryParse(o.LeaksQty, out TotalLeaks);
                            TotalLeaks = Math.Round(TotalLeaks, 2);
                            cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                            cmd.Parameters.Add("@ProductID", o.ProductID);
                            cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@VarifyStatus", 'P');
                            cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  Leakages(ReturnQty,TotalLeaks,ProductID,TripID,VarifyStatus,EntryDate,VarifyReturnStatus,invoiceno) Values (@ReturnQty,@TotalLeaks,@ProductID,@TripID,@VarifyStatus,@EntryDate,@VarifyReturnStatus,@invoiceno)");
                                cmd.Parameters.Add("@ReturnQty", ReturnQty);
                                cmd.Parameters.Add("@TotalLeaks", TotalLeaks);
                                cmd.Parameters.Add("@ProductID", o.ProductID);
                                cmd.Parameters.Add("@EntryDate", ServerDateCurrentdate);
                                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@VarifyStatus", 'P');
                                cmd.Parameters.Add("@VarifyReturnStatus", 'P');
                                cmd.Parameters.Add("@invoiceno", invno);
                                vdm.insert(cmd);
                            }
                        }
                    }
                }
                string msg = "Data Saved Successfully";
                string msgresponse = GetJson(msg);
                context.Response.Write(msgresponse);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string msgresponse = GetJson(msg);
                context.Response.Write(msgresponse);
            }
        }
        private void getOrderStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["Bid"];
                string IndentType = context.Request["IndentType"];
                if (IndentType == "")
                {
                    IndentType = context.Session["IndentType"].ToString();
                }
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType = @IndentType)");
                cmd.Parameters.Add("@Branch_id", BranchID);
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                if (dtIndent.Rows.Count > 0)
                {
                    string msg = "Indent Completed";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        private void GetTripNo(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                string RouteSno = context.Request["RouteSno"];
                string DispDate = context.Session["DispDate"].ToString();
                DateTime dtDispDate = Convert.ToDateTime(DispDate);
                cmd = new MySqlCommand("SELECT tripdata.Sno FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (tripdata.I_Date BETWEEN @d1 AND @d2) AND (triproutes.RouteID = @RouteID) AND (tripdata.Status = @Status)");
                //cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status");
                cmd.Parameters.Add("@Status", 'A');
                cmd.Parameters.Add("@RouteID", RouteSno);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                String TripID = "";
                if (dtTripID.Rows.Count > 0)
                {
                    TripID = dtTripID.Rows[0]["Sno"].ToString();
                    context.Session["DispTripSno"] = dtTripID.Rows[0]["Sno"].ToString();
                }
                else
                {
                    context.Session["DispTripSno"] = null;
                }
                string response = GetJson(TripID);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetDispInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Inventory> Inventorylist = new List<Inventory>();
                string DispTripSno = "";
                if (context.Session["DispTripSno"] != null)
                {
                    DispTripSno = context.Session["DispTripSno"].ToString();
                }
                string DispType = context.Session["DispType"].ToString();
                DataTable dtInvData = new DataTable();
                if (DispType == "SO")
                {
                    cmd = new MySqlCommand("SELECT invmaster.sno, invmaster.InvName, inventory_monitor.Qty as Remaining FROM inventory_monitor INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (inventory_monitor.BranchId = @branchID)");
                    cmd.Parameters.Add("@branchID", context.Session["CsoNo"].ToString());
                    dtInvData = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName,tripinvdata.Remaining, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                    dtInvData = vdm.SelectQuery(cmd).Tables[0];
                }
                cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                cmd.Parameters.Add("@Tripdata_sno", DispTripSno);
                DataTable dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevInventory.Rows.Count == 0)
                {
                    context.Session["dtPrevInventory"] = "";
                    DataTable dtInventory = new DataTable();
                    if (context.Session["dtInventory"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                        dtInventory = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtInventory = (DataTable)context.Session["dtInventory"];
                    }
                    int i = 1;
                    foreach (DataRow dr in dtInventory.Rows)
                    {
                        foreach (DataRow drsubInv in dtInvData.Rows)
                        {
                            if (dr["sno"].ToString() == drsubInv["sno"].ToString())
                            {
                                Inventory GetInventory = new Inventory();
                                GetInventory.Sno = i++.ToString();
                                GetInventory.InvSno = dr["sno"].ToString();
                                GetInventory.InvName = dr["InvName"].ToString();
                                GetInventory.Invqty = "";
                                GetInventory.RemainQty = drsubInv["Remaining"].ToString();
                                Inventorylist.Add(GetInventory);
                            }
                        }
                    }
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
                else
                {
                    context.Session["dtPrevInventory"] = dtPrevInventory;
                    DataTable DtTotalInv = new DataTable();
                    DataTable dtInventory = new DataTable();
                    if (context.Session["dtInventory"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                        dtInventory = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtInventory = (DataTable)context.Session["dtInventory"];
                    }
                    DtTotalInv.Columns.Add("sno");
                    DtTotalInv.Columns.Add("InvName");
                    DtTotalInv.Columns.Add("Qty");
                    foreach (DataRow dr in dtInventory.Rows)
                    {
                        DataRow newRow = DtTotalInv.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["InvName"] = dr["InvName"].ToString();
                        newRow["Qty"] = "0";
                        DtTotalInv.Rows.Add(newRow);
                    }
                    foreach (DataRow drDisp in dtPrevInventory.Rows)
                    {
                        foreach (DataRow drtotprod in DtTotalInv.Rows)
                        {

                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {

                                //foreach (DataRow dr in dtPrevInventory.Rows)
                                //{
                                float qty = 0;
                                float.TryParse(drDisp["Qty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["Qty"].ToString(), out qtycpy);

                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["Qty"] = Math.Round(totalqty, 2);

                                //}
                            }
                        }
                    }
                    int i = 1;
                    foreach (DataRow drtotprod in DtTotalInv.Rows)
                    {
                        foreach (DataRow drsubInv in dtInvData.Rows)
                        {
                            if (drtotprod["sno"].ToString() == drsubInv["sno"].ToString())
                            {
                                Inventory GetInventory = new Inventory();
                                GetInventory.Sno = i++.ToString();
                                GetInventory.InvSno = drtotprod["sno"].ToString();
                                GetInventory.InvName = drtotprod["InvName"].ToString();
                                GetInventory.Invqty = drtotprod["Qty"].ToString();
                                int Qty = 0;
                                int.TryParse(drtotprod["Qty"].ToString(), out Qty);
                                int Remaining = 0;
                                int.TryParse(drsubInv["Remaining"].ToString(), out Remaining);
                                GetInventory.RemainQty = Remaining.ToString();
                                Inventorylist.Add(GetInventory);
                            }
                        }
                    }
                    string response = GetJson(Inventorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Inventory
        {
            public string Sno { get; set; }
            public string InvSno { get; set; }
            public string InvName { get; set; }
            public string Invqty { get; set; }
            public string RemainQty { get; set; }
        }
        private void GetCollectionStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string TodayAmount = "0";
                string BranchID = context.Request["BranchID"];
                cmd = new MySqlCommand("SELECT AmountPaid FROM collections where BranchID=@BranchID and tripId=@tripId");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@tripId", context.Session["TripdataSno"].ToString());
                DataTable dtTodayAmount = vdm.SelectQuery(cmd).Tables[0];
                if (dtTodayAmount.Rows.Count > 0)
                {
                    TodayAmount = dtTodayAmount.Rows[0]["AmountPaid"].ToString();
                    context.Session["AmountPaid"] = dtTodayAmount.Rows[0]["AmountPaid"].ToString();
                }
                else
                {
                    TodayAmount = "0";
                    context.Session["AmountPaid"] = "";
                }
                string response = GetJson(TodayAmount);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void btnShoratageSaveClick(HttpContext context)
        {
            try
            {
                if (context.Session["TripID"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            string SalesType = context.Session["Salestype"].ToString();
                            string TripID = "";
                            if (SalesType == "Plant")
                            {
                                TripID = context.Session["TripdataSno"].ToString();
                            }
                            else
                            {
                                TripID = context.Session["TripID"].ToString();

                            }
                            cmd = new MySqlCommand("update leakages set  EntryDate=@EntryDate,ShortQty=@ShortQty,LeakQty=@LeakQty,FreeMilk=@FreeMilk where TripID=@TripID and ProductID=@ProductID");
                            cmd.Parameters.Add("@TripID", TripID);
                            cmd.Parameters.Add("@EntryDate", Currentdate);
                            cmd.Parameters.Add("@ProductID", o.Productsno);
                            double ShortQty = 0;
                            double.TryParse(o.ShortQty, out ShortQty);
                            ShortQty = Math.Round(ShortQty, 2);
                            cmd.Parameters.Add("@ShortQty", ShortQty);
                            double LeakQty = 0;
                            double.TryParse(o.LeakQty, out LeakQty);
                            LeakQty = Math.Round(LeakQty, 2);
                            cmd.Parameters.Add("@LeakQty", LeakQty);
                            double FreeMilk = 0;
                            double.TryParse(o.FreeMilk, out FreeMilk);
                            FreeMilk = Math.Round(FreeMilk, 2);
                            cmd.Parameters.Add("@FreeMilk", FreeMilk);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("insert into leakages (TripID,EntryDate,ProductID,ShortQty,LeakQty,FreeMilk)values(@TripID,@EntryDate,@ProductID,@ShortQty,@LeakQty,@FreeMilk)");
                                cmd.Parameters.Add("@TripID", TripID);
                                cmd.Parameters.Add("@EntryDate", Currentdate);
                                cmd.Parameters.Add("@ProductID", o.Productsno);
                                cmd.Parameters.Add("@ShortQty", ShortQty);
                                cmd.Parameters.Add("@LeakQty", LeakQty);
                                cmd.Parameters.Add("@FreeMilk", FreeMilk);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    string msg = "Data Successfully Saved";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetShortageProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Products> Productlist = new List<Products>();
                string TripID = "";
                if (context.Session["DispTripSno"] != null)
                {
                    TripID = context.Session["DispTripSno"].ToString();
                }
                else
                {
                    if (context.Session["TripdataSno"] != null)
                    {
                        TripID = context.Session["TripdataSno"].ToString();
                    }
                    else
                    {
                        TripID = "";
                    }
                }
                cmd = new MySqlCommand("SELECT productsdata.ProductName, leakages.ShortQty, leakages.LeakQty,leakages.FreeMilk, productsdata.sno FROM leakages INNER JOIN productsdata ON leakages.ProductID = productsdata.sno where leakages.TripID=@TripID Group by productsdata.ProductName  ORDER BY productsdata.sno");
                cmd.Parameters.Add("@TripID", TripID);
                DataTable dtPrevdata = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevdata.Rows.Count == 0)
                {
                    DataTable dtproductsdata = new DataTable();
                    if (context.Session["dtproductsdata"] == null)
                    {
                        cmd = new MySqlCommand("SELECT sno, ProductName FROM productsdata ORDER BY sno");
                        dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                    }
                    int i = 1;
                    foreach (DataRow dr in dtproductsdata.Rows)
                    {
                        Products GetProducts = new Products();
                        GetProducts.sno = i++.ToString();
                        GetProducts.Productsno = dr["sno"].ToString();
                        GetProducts.ProductCode = dr["ProductName"].ToString();
                        GetProducts.ShortQty = "";
                        GetProducts.LeakQty = "";
                        GetProducts.FreeMilk = "";
                        Productlist.Add(GetProducts);
                    }
                    string response = GetJson(Productlist);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.sno, tripsubdata.ProductId, tripsubdata.DeliverQty FROM productsdata INNER JOIN tripsubdata ON productsdata.sno = tripsubdata.ProductId WHERE (tripsubdata.Tripdata_sno = @TripID)ORDER BY productsdata.sno");
                    cmd.Parameters.Add("@TripID", TripID);
                    DataTable dtSubData = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtallProducts = new DataTable();
                    dtallProducts.Columns.Add("sno");
                    dtallProducts.Columns.Add("ProductName");
                    dtallProducts.Columns.Add("ShortQty");
                    dtallProducts.Columns.Add("LeakQty");
                    dtallProducts.Columns.Add("FreeMilk");
                    foreach (DataRow dr in dtSubData.Rows)
                    {
                        DataRow newRow = dtallProducts.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["ProductName"] = dr["ProductName"].ToString();
                        newRow["ShortQty"] = "0";
                        newRow["LeakQty"] = "0";
                        newRow["FreeMilk"] = "0";
                        dtallProducts.Rows.Add(newRow);
                    }
                    int i = 1;
                    foreach (DataRow drSub in dtallProducts.Rows)
                    {
                        foreach (DataRow dr in dtPrevdata.Rows)
                        {
                            if (drSub["sno"].ToString() == dr["sno"].ToString())
                            {
                                drSub["ShortQty"] = dr["ShortQty"].ToString();
                                drSub["LeakQty"] = dr["LeakQty"].ToString();
                                drSub["FreeMilk"] = dr["FreeMilk"].ToString();

                            }
                        }
                    }
                    foreach (DataRow dr in dtallProducts.Rows)
                    {
                        Products GetProducts = new Products();
                        GetProducts.sno = i++.ToString();
                        GetProducts.Productsno = dr["sno"].ToString();
                        GetProducts.ProductCode = dr["ProductName"].ToString();
                        GetProducts.ShortQty = dr["ShortQty"].ToString();
                        GetProducts.LeakQty = dr["LeakQty"].ToString();
                        GetProducts.FreeMilk = dr["FreeMilk"].ToString();
                        Productlist.Add(GetProducts);
                    }
                    string response = GetJson(Productlist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Products
        {
            public string sno { get; set; }
            public string ProductCode { get; set; }
            public string Productsno { get; set; }
            public string ShortQty { get; set; }
            public string LeakQty { get; set; }
            public string ReturnQty { get; set; }
            public string FreeMilk { get; set; }

        }
        private void btnDispatchSaveClick(HttpContext context)
        {
            try
            {
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string EmpID = obj.EmpName;
                    string RouteId = obj.RouteId;
                    string DispDate = context.Session["DispDate"].ToString();
                    DateTime dtDispDate = Convert.ToDateTime(DispDate);
                    string VehicleNo = "";
                    DataTable dtTotalProducts = new DataTable();
                    DataTable dtPrevInventory = new DataTable();
                    string Mode = obj.Mode;
                    string DispType = context.Session["DispType"].ToString();

                    //if (Mode != "Delete")
                    //{
                    cmd = new MySqlCommand("SELECT tripdata.Sno FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (tripdata.I_Date BETWEEN @d1 AND @d2) AND ( triproutes.RouteID = @RouteID ) AND (tripdata.Status = @Status)");
                    //cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status and ATripid=@ATripid");
                    cmd.Parameters.Add("@Status", 'A');
                    cmd.Parameters.Add("@RouteID", RouteId);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                    DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                    if (dtTripID.Rows.Count > 0)
                    {
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        if (context.Session["dtTripSubData"] == null)
                        {
                            cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.Qty, productsdata.sno FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno where tripsubdata.Tripdata_sno=@Tripdata_sno and tripdata.Status=@Status and tripdata.I_Date between @d1 and @d2 and tripdata.EmpId=@EmpId");
                            cmd.Parameters.Add("@Tripdata_sno", dtTripID.Rows[0]["Sno"].ToString());
                            cmd.Parameters.Add("@Status", 'A');
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtDispDate));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtDispDate));
                            cmd.Parameters.Add("@EmpId", EmpID);
                            dtTotalProducts = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["dtTripSubData"] = dtTotalProducts;
                        }
                        else
                        {
                            dtTotalProducts = (DataTable)context.Session["dtTripSubData"];
                        }
                        if (context.Session["dtPrevInventory"] == null || context.Session["dtPrevInventory"] == "" )
                        {
                            cmd = new MySqlCommand("SELECT tripinvdata.invid,invmaster.sno, invmaster.InvName, tripinvdata.Qty FROM  tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno where  tripinvdata.Tripdata_sno=@Tripdata_sno");
                            cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                            dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["dtPrevInventory"] = dtPrevInventory;
                        }
                        else
                        {
                            dtPrevInventory = (DataTable)context.Session["dtPrevInventory"];
                        }
                        cmd = new MySqlCommand("Update  tripdata set  AssignDate=@AssignDate,Status=@Status,I_Date=@I_Date,DEmpId=@DEmpId,EmpId=@EmpId where  Sno=@Sno and ATripid=@ATripid");
                        cmd.Parameters.Add("@Sno", dtTripID.Rows[0]["Sno"].ToString());
                        cmd.Parameters.Add("@Permissions", "D;C");
                        cmd.Parameters.Add("@EmpId", EmpID);
                        cmd.Parameters.Add("@AssignDate", Currentdate);
                        cmd.Parameters.Add("@I_Date", dtDispDate);
                        cmd.Parameters.Add("@DEmpId", context.Session["PlantEmpId"].ToString());
                        cmd.Parameters.Add("@status", "A");
                        cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                        vdm.Update(cmd);
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("Update tripsubdata set Qty=@Qty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                float Dispqty = 0;
                                float.TryParse(o.RemainQty, out Dispqty);
                                cmd.Parameters.Add("@Qty", Dispqty);
                                if (Dispqty != 0.0)
                                {
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@DeliverQty)");
                                        cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                        cmd.Parameters.Add("@ProductId", o.Productsno);
                                        float.TryParse(o.RemainQty, out Dispqty);
                                        cmd.Parameters.Add("@Qty", Dispqty);
                                        cmd.Parameters.Add("@DeliverQty", 0);

                                        vdm.insert(cmd);
                                    }
                                }
                                foreach (DataRow dr in dtTotalProducts.Rows)
                                {
                                    string ProduSno = o.Productsno;
                                    string Psno = dr["sno"].ToString();
                                    if (ProduSno == Psno)
                                    {
                                        double PQty = 0;
                                        double.TryParse(dr["Qty"].ToString(), out PQty);
                                        double DQty = 0;
                                        double.TryParse(o.RemainQty, out DQty);
                                        double TQty = DQty - PQty;
                                        if (TQty >= 1)
                                        {
                                            TQty = Math.Round(TQty, 2);
                                            if (DispType == "SO")
                                            {
                                                cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty+@BranchQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                                                cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                                cmd.Parameters.Add("@BranchQty", TQty);
                                                vdm.Update(cmd);
                                            }
                                            else
                                            {
                                                cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                                cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                                cmd.Parameters.Add("@DeliverQty", TQty);
                                                vdm.Update(cmd);
                                            }
                                        }
                                        else
                                        {
                                            TQty = Math.Abs(TQty);
                                            TQty = Math.Round(TQty, 2);
                                            if (DispType == "SO")
                                            {
                                                cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty-@BranchQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                                                cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                                cmd.Parameters.Add("@BranchQty", TQty);
                                                vdm.Update(cmd);

                                            }
                                            else
                                            {
                                                cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty-@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                                cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                                cmd.Parameters.Add("@DeliverQty", TQty);
                                                vdm.Update(cmd);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        foreach (Inventorydetail o in obj.Inventorydetails)
                        {
                            if (o.InvSno != null)
                            {
                                if (dtPrevInventory.Rows.Count > 0)
                                {
                                    cmd = new MySqlCommand("Update tripinvdata set Qty=@Qty,Remaining=@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                    cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                    cmd.Parameters.Add("@invid", o.InvSno);
                                    cmd.Parameters.Add("@Qty", o.ReceivedQty);
                                    cmd.Parameters.Add("@Remaining", o.ReceivedQty);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into tripinvdata(Tripdata_Sno,invid,Qty,Remaining) values(@Tripdata_Sno,@invid,@Qty,@Remaining)");
                                        cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                        cmd.Parameters.Add("@invid", o.InvSno);
                                        int ReceivedQty = 0;
                                        int.TryParse(o.ReceivedQty, out ReceivedQty);
                                        cmd.Parameters.Add("@Qty", ReceivedQty);
                                        cmd.Parameters.Add("@Remaining", ReceivedQty);
                                        vdm.insert(cmd);
                                    }
                                    foreach (DataRow dr in dtPrevInventory.Rows)
                                    {
                                        string invSno = o.InvSno;
                                        string pInvsno = dr["sno"].ToString();
                                        if (pInvsno == invSno)
                                        {
                                            float PIQty = 0;
                                            float.TryParse(dr["Qty"].ToString(), out PIQty);
                                            float DIQty = 0;
                                            float.TryParse(o.ReceivedQty, out DIQty);
                                            float TIQty = DIQty - PIQty;
                                            if (TIQty >= 1)
                                            {
                                                if (DispType == "SO")
                                                {
                                                    cmd = new MySqlCommand("Update inventory_monitor set Qty=Qty+@Qty where  Inv_sno=@Inv_sno and BranchId=@BranchId");
                                                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                                    cmd.Parameters.Add("@Inv_sno", o.InvSno);
                                                    cmd.Parameters.Add("@Qty", TIQty);
                                                    vdm.Update(cmd);
                                                }
                                                else
                                                {
                                                    cmd = new MySqlCommand("Update tripinvdata set Qty=Qty+@Qty,Remaining=Remaining+@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                                    cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                                    cmd.Parameters.Add("@invid", o.InvSno);
                                                    cmd.Parameters.Add("@Qty", TIQty);
                                                    cmd.Parameters.Add("@Remaining", TIQty);
                                                    vdm.Update(cmd);
                                                }
                                            }
                                            else
                                            {
                                                TIQty = Math.Abs(TIQty);
                                                if (DispType == "SO")
                                                {
                                                    cmd = new MySqlCommand("Update inventory_monitor set Qty=Qty-@Qty where  Inv_sno=@Inv_sno and BranchId=@BranchId");
                                                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                                    cmd.Parameters.Add("@Inv_sno", o.InvSno);
                                                    cmd.Parameters.Add("@Qty", TIQty);
                                                    vdm.Update(cmd);
                                                }
                                                else
                                                {
                                                    cmd = new MySqlCommand("Update tripinvdata set Qty=Qty-@Qty,Remaining=Remaining-@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                                    cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                                    cmd.Parameters.Add("@invid", o.InvSno);
                                                    cmd.Parameters.Add("@Qty", TIQty);
                                                    cmd.Parameters.Add("@Remaining", TIQty);
                                                    vdm.Update(cmd);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    cmd = new MySqlCommand("Update tripinvdata set Qty=@Qty,Remaining=@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                    cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                    cmd.Parameters.Add("@invid", o.InvSno);
                                    cmd.Parameters.Add("@Qty", o.ReceivedQty);
                                    cmd.Parameters.Add("@Remaining", o.ReceivedQty);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("Insert Into tripinvdata(Tripdata_Sno,invid,Qty,Remaining) values(@Tripdata_Sno,@invid,@Qty,@Remaining)");
                                        cmd.Parameters.Add("@Tripdata_Sno", dtTripID.Rows[0]["Sno"].ToString());
                                        cmd.Parameters.Add("@invid", o.InvSno);
                                        int ReceivedQty = 0;
                                        int.TryParse(o.ReceivedQty, out ReceivedQty);
                                        cmd.Parameters.Add("@Qty", ReceivedQty);
                                        cmd.Parameters.Add("@Remaining", ReceivedQty);
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("update tripdata set Status=@status where Status=@St  and  EmpId='" + EmpID + "'");
                        cmd.Parameters.Add("@status", 'C');
                        cmd.Parameters.Add("@St", 'A');
                        vdm.Update(cmd);
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        DateTime dtapril = new DateTime();
                        DateTime dtmarch = new DateTime();
                        int currentyear = Currentdate.Year;
                        int nextyear = Currentdate.Year + 1;
                        if (Currentdate.Month > 3)
                        {
                            string apr = "4/1/" + currentyear;
                            dtapril = DateTime.Parse(apr);
                            string march = "3/31/" + nextyear;
                            dtmarch = DateTime.Parse(march);
                        }
                        if (Currentdate.Month <= 3)
                        {
                            string apr = "4/1/" + (currentyear - 1);
                            dtapril = DateTime.Parse(apr);
                            string march = "3/31/" + (nextyear - 1);
                            dtmarch = DateTime.Parse(march);
                        }
                       // cmd = new MySqlCommand("Select IFNULL(MAX(DCNO),0)+1 as Sno  from tripdata where BranchID=@BranchID");
                        cmd = new MySqlCommand("SELECT IFNULL(MAX(DCNo), 0) + 1 AS Sno FROM tripdata WHERE (BranchID = @BranchID) AND (AssignDate BETWEEN @d1 AND @d2)");
                        cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtapril));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtmarch));
                        DataTable dtTripId = vdm.SelectQuery(cmd).Tables[0];
                        string TripDCNo = dtTripId.Rows[0]["Sno"].ToString();
                        cmd = new MySqlCommand("insert into tripdata (EmpId,AssignDate,Status,Userdata_sno,Permissions,VehicleNo,I_Date,DEmpId,ATripid,BranchID,Dcno)values(@EmpId,@AssignDate,@status,@Userdata_sno,@Permissions,@VehicleNo,@I_Date,@DEmpId,@ATripid,@BranchID,@Dcno)");
                        //cmd.Parameters.Add("@Branch_id", BranchID);
                        //cmd.Parameters.Add("@TotalQty", Qty);
                        cmd.Parameters.Add("@Permissions", "D;C");
                        // cmd.Parameters.Add("@RouteId", RouteID);
                        //cmd.Parameters.Add("@RouteId", obj.routename);
                        cmd.Parameters.Add("@EmpId", EmpID);
                        cmd.Parameters.Add("@AssignDate", Currentdate);
                        cmd.Parameters.Add("@I_Date", dtDispDate);
                        cmd.Parameters.Add("@DEmpId", context.Session["PlantEmpId"].ToString());
                        cmd.Parameters.Add("@status", "A");
                        cmd.Parameters.Add("@VehicleNo", VehicleNo);
                        cmd.Parameters.Add("@Userdata_sno", context.Session["userdata_sno"]);
                        cmd.Parameters.Add("@ATripid", context.Session["PlantDispSno"].ToString());
                        cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                        cmd.Parameters.Add("@Dcno", TripDCNo);
                        long TripSno = vdm.insertScalar(cmd);
                        context.Session["TripIDSno"] = TripSno;
                        //foreach (string word in words)
                        //{
                        cmd = new MySqlCommand("insert into triproutes(Tripdata_sno,RouteID)values(@tripdata_sno,@routeid) ");
                        cmd.Parameters.Add("@tripdata_sno", TripSno);
                        cmd.Parameters.Add("@routeid", RouteId);
                        vdm.insert(cmd);

                        //}
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@DeliverQty)");
                                cmd.Parameters.Add("@Tripdata_Sno", TripSno);
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                double Dispqty = 0;
                                double.TryParse(o.RemainQty, out Dispqty);
                                Dispqty = Math.Round(Dispqty, 2);
                                cmd.Parameters.Add("@Qty", Dispqty);
                                float dispQty = 0;
                                cmd.Parameters.Add("@DeliverQty", dispQty);

                                if (Dispqty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                                if (DispType == "SO")
                                {
                                    cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty-@BranchQty where Branch_sno=@Branch_sno and Product_sno=@Product_sno");
                                    cmd.Parameters.Add("@Branch_sno", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    cmd.Parameters.Add("@BranchQty", Dispqty);
                                    vdm.Update(cmd);
                                }
                                else
                                {
                                    cmd = new MySqlCommand("Update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                    cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                    cmd.Parameters.Add("@ProductId", o.Productsno);
                                    cmd.Parameters.Add("@DeliverQty", Dispqty);
                                    vdm.Update(cmd);
                                }
                            }
                        }
                        foreach (Inventorydetail o in obj.Inventorydetails)
                        {
                            if (o.InvSno != null)
                            {
                                cmd = new MySqlCommand("Insert Into tripinvdata(Tripdata_Sno,invid,Qty,Remaining) values(@Tripdata_Sno,@invid,@Qty,@Remaining)");
                                cmd.Parameters.Add("@Tripdata_Sno", TripSno);
                                cmd.Parameters.Add("@invid", o.InvSno);
                                int ReceivedQty = 0;
                                int.TryParse(o.ReceivedQty, out ReceivedQty);
                                cmd.Parameters.Add("@Qty", ReceivedQty);
                                cmd.Parameters.Add("@Remaining", ReceivedQty);
                                vdm.insert(cmd);
                                if (DispType == "SO")
                                {
                                    cmd = new MySqlCommand("Update inventory_monitor set Qty=Qty-@Qty where  Inv_sno=@Inv_sno and BranchId=@BranchId");
                                    cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@Inv_sno", o.InvSno);
                                    cmd.Parameters.Add("@Qty", o.ReceivedQty);
                                    vdm.Update(cmd);
                                }
                                else
                                {
                                    cmd = new MySqlCommand("Update tripinvdata set Remaining=Remaining-@Remaining where  Tripdata_Sno=@Tripdata_Sno and invid=@invid");
                                    cmd.Parameters.Add("@Tripdata_Sno", context.Session["PlantDispSno"].ToString());
                                    cmd.Parameters.Add("@invid", o.InvSno);
                                    cmd.Parameters.Add("@Remaining", o.ReceivedQty);
                                    vdm.Update(cmd);
                                }
                            }
                        }
                    }
                    cmd = new MySqlCommand("SELECT UserName, Mobno,Sno FROM empmanage where Sno=@EmpID");
                    cmd.Parameters.Add("@EmpID", EmpID);
                    DataTable dtEmp = vdm.SelectQuery(cmd).Tables[0];
                    string EmpName = dtEmp.Rows[0]["UserName"].ToString();
                    string phonenumber = dtEmp.Rows[0]["Mobno"].ToString();
                    string empid = dtEmp.Rows[0]["sno"].ToString();
                    
                    string Date = DateTime.Now.ToString("dd/MM/yyyy");
                    cmd = new MySqlCommand("SELECT DispName FROM dispatch where sno=@dispatchSno");
                    cmd.Parameters.Add("@dispatchSno", RouteId);
                    DataTable dtRoute = vdm.SelectQuery(cmd).Tables[0];
                    string DispName = dtRoute.Rows[0]["DispName"].ToString();
                    string ProductName = "";
                    double TotalQty = 0;
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.RemainQty != "0")
                        {
                            float RemainQty = 0;
                            float.TryParse(o.RemainQty, out RemainQty);
                            ProductName += o.Product + "=" + Math.Round(RemainQty, 2) + ";";
                            TotalQty += Math.Round(RemainQty, 2);
                        }
                    }
                    if (phonenumber.Length == 10)
                    {

                         string BranchSno = context.Session["CsoNo"].ToString();
                         if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                         {

                             WebClient client = new WebClient();
                             //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                             string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + EmpName + "%20,%20" + DispName + "%20 + Dispatch%20Completed%20Successfully%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 
                            
                            // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + EmpName + "%20,%20" + DispName + "%20 + Dispatch%20Completed%20Successfully%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                             Stream data = client.OpenRead(baseurl);
                             StreamReader reader = new StreamReader(data);
                             string ResponseID = reader.ReadToEnd();
                             data.Close();
                             reader.Close();
                         }
                         else
                         {
                             WebClient client = new WebClient();
                             //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                             string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + EmpName + "%20,%20" + DispName + "%20 + Dispatch%20Completed%20Successfully%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 
                            // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + EmpName + "%20,%20" + DispName + "%20 + Dispatch%20Completed%20Successfully%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                             Stream data = client.OpenRead(baseurl);
                             StreamReader reader = new StreamReader(data);
                             string ResponseID = reader.ReadToEnd();
                             data.Close();
                             reader.Close();
                         }

                        string message = "  Dear " + EmpName + " ,   " + DispName + "  + Dispatch Completed Successfully " + Date + " , " + ProductName + "Total Ltrs =" + TotalQty + " "; 
                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", empid);
                        cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "OnlineDispatch");
                        cmd.Parameters.Add("@branchname", EmpName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    List<string> MsgList = new List<string>();
                    string msg = "Data Successfully Saved";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetDispProducts(HttpContext context)
        {
            try
            {
                DataTable dtTotalProducts = new DataTable();
                vdm = new VehicleDBMgr();
                string RouteId = context.Request["RouteId"];
                cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.sno = @DispSno)");
                cmd.Parameters.Add("@DispSno", RouteId);
                DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                string IndentType = dtIndent.Rows[0]["IndentType"].ToString();
                if (IndentType == "")
                {
                    IndentType = "Indent1";
                }
                string txtDispDate = context.Session["DispDate"].ToString();
                DateTime Currentdate = Convert.ToDateTime(txtDispDate);
                string EmpID = context.Request["EmpID"];
                DataTable dtproductsdata = new DataTable();
                //if (context.Session["dtproductsdata"] == null)
                //{
                cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) order by branchproducts.Rank");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                //}
                //else
                //{
                //    dtproductsdata = (DataTable)context.Session["dtproductsdata"];
                //}
                dtTotalProducts.Columns.Add("sno");
                dtTotalProducts.Columns.Add("ProductName");
                dtTotalProducts.Columns.Add("TotalQty");
                dtTotalProducts.Columns.Add("DispQty");
                foreach (DataRow dr in dtproductsdata.Rows)
                {
                    DataRow newRow = dtTotalProducts.NewRow();
                    newRow["sno"] = dr["sno"].ToString();
                    newRow["ProductName"] = dr["ProductName"].ToString();
                    newRow["TotalQty"] = "0";
                    newRow["DispQty"] = "0";
                    dtTotalProducts.Rows.Add(newRow);
                }
                string DispType = context.Session["DispType"].ToString();
                DataTable dtsubtrip = new DataTable();
                if (DispType == "SO")
                {
                    cmd = new MySqlCommand("SELECT productsdata.ProductName, branchproducts.BranchQty as subdataQty, branchproducts.product_sno as ProductId FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @branchID)");
                    cmd.Parameters.Add("@branchID", context.Session["CsoNo"].ToString());
                    dtsubtrip = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName ,ROUND(tripsubdata.Qty,2) as subdataQty,ROUND(tripsubdata.DeliverQty,2) as DeliverQty  FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.Tripdata_sno = @Tripdata_sno) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId) GROUP BY productsdata.ProductName");
                    cmd.Parameters.Add("@Tripdata_sno", context.Session["PlantDispSno"].ToString());
                    cmd.Parameters.Add("@EmpId", context.Session["PlantEmpId"].ToString());
                    dtsubtrip = vdm.SelectQuery(cmd).Tables[0];
                }
                cmd = new MySqlCommand("SELECT tripdata.Sno FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (tripdata.I_Date BETWEEN @d1 AND @d2) AND ( triproutes.RouteID = @RouteID ) AND (tripdata.Status = @Status)");
                //cmd = new MySqlCommand("SELECT Sno FROM tripdata where I_Date between @d1 and @d2 and EmpID=@EmpID and Status=@Status");
                cmd.Parameters.Add("@Status", 'A');
                //cmd.Parameters.Add("@EmpID", EmpID);
                cmd.Parameters.Add("@RouteID", RouteId);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtTripID = vdm.SelectQuery(cmd).Tables[0];
                if (dtTripID.Rows.Count > 0)
                {
                    cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.Qty, productsdata.sno, triproutes.Tripdata_sno FROM  tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (tripdata.I_Date BETWEEN @d1 AND @d2) AND (triproutes.RouteID = @RouteID) AND (tripdata.Status = @Status) AND (tripsubdata.Tripdata_sno = @Tripdata_sno)");
                    //cmd = new MySqlCommand("SELECT productsdata.ProductName, tripsubdata.Qty, productsdata.sno FROM tripsubdata INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN tripdata ON tripsubdata.Tripdata_sno = tripdata.Sno where tripsubdata.Tripdata_sno=@Tripdata_sno and tripdata.Status=@Status and tripdata.I_Date between @d1 and @d2 and tripdata.EmpId=@EmpId");
                    cmd.Parameters.Add("@Tripdata_sno", dtTripID.Rows[0]["Sno"].ToString());
                    cmd.Parameters.Add("@Status", 'A');
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    //cmd.Parameters.Add("@EmpId", EmpID);
                    cmd.Parameters.Add("@RouteID", RouteId);
                    DataTable dtTripSubData = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["dtTripSubData"] = dtTripSubData;


                    string routeid = "";
                    string routeitype = "";
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", RouteId);
                    DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                    {
                        routeid = drrouteitype["Route_id"].ToString();
                        routeitype = drrouteitype["IndentType"].ToString();
                    }

                    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, indents_subtable.UnitCost, indent.Branch_id, indents_subtable.Product_sno FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @starttime AND @endtime)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @starttime) OR (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate > @starttime) AND (modifiedroutesubtable.CDate <= @starttime) GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno");
                    cmd.Parameters.Add("@TripID", routeid);
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@itype", routeitype);
                    DataTable dtDispProducts = vdm.SelectQuery(cmd).Tables[0];

                    //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id AND indents.IndentType = dispatch_sub.IndentType INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName ORDER BY TotalQty");
                    //////cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (indents.I_date between @d1 AND  @d2) AND (indents.IndentType = @IndentType) AND (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName ORDER BY TotalQty");
                    //cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    //cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    //cmd.Parameters.Add("@RouteID", RouteId);
                    //cmd.Parameters.Add("@IndentType", IndentType);
                    //DataTable dtDispProducts = vdm.SelectQuery(cmd).Tables[0];
                    //dtDispProducts.DefaultView.Sort = "sno ASC";
                    //dtDispProducts = dtDispProducts.DefaultView.ToTable(true);
                    foreach (DataRow drDisp in dtDispProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTotalProducts.Rows)
                        {

                            if (drDisp["Product_sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drDisp["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["TotalQty"].ToString(), out qtycpy);
                                float totalqty = qty + qtycpy;
                                drtotprod["TotalQty"] = totalqty;
                            }
                        }
                    }
                    dtTotalProducts.DefaultView.Sort = "sno ASC";
                    dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    foreach (DataRow drDisp in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTripSubData.Rows)
                        {
                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                string dispqty = "";
                                dispqty = drtotprod["Qty"].ToString();
                                if (dispqty == "0")
                                {
                                    dispqty = "";
                                }
                                drDisp["DispQty"] = dispqty;
                            }
                        }
                    }
                    List<dispProducts> Displist = new List<dispProducts>();
                    int i = 1;
                    dtTotalProducts.DefaultView.Sort = "sno ASC";
                    dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    dtsubtrip.DefaultView.Sort = "ProductId ASC";
                    dtsubtrip = dtsubtrip.DefaultView.ToTable(true);
                    foreach (DataRow dr in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drsub in dtsubtrip.Rows)
                        {
                            if (dr["sno"].ToString() == drsub["ProductId"].ToString())
                            {
                                dispProducts getdispProducts = new dispProducts();
                                getdispProducts.sno = i++.ToString();
                                getdispProducts.ProductCode = dr["ProductName"].ToString();
                                getdispProducts.Productsno = dr["sno"].ToString();
                                getdispProducts.Qty = dr["TotalQty"].ToString();
                                float Qty = 0;
                                float.TryParse(dr["TotalQty"].ToString(), out Qty);
                                float subdataQty = 0;
                                float.TryParse(drsub["subdataQty"].ToString(), out subdataQty);
                                float DeliverQty = 0;
                                if (DispType == "SO")
                                {
                                }
                                else
                                {
                                    float.TryParse(drsub["DeliverQty"].ToString(), out DeliverQty);
                                }
                                float RemainQty = subdataQty - DeliverQty;
                                getdispProducts.RemainQty = RemainQty.ToString();
                                getdispProducts.DispQty = dr["DispQty"].ToString();
                                Displist.Add(getdispProducts);
                            }
                        }
                    }
                    string response = GetJson(Displist);
                    context.Response.Write(response);
                }
                else
                {
                    string routeid = "";
                    string routeitype = "";
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", RouteId);
                    DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                    {
                        routeid = drrouteitype["Route_id"].ToString();
                        routeitype = drrouteitype["IndentType"].ToString();
                    }

                    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, indents_subtable.UnitCost, indent.Branch_id, indents_subtable.Product_sno FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @starttime AND @endtime)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @starttime) OR (modifiedroutes.Sno = @TripID) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) AND (modifiedroutesubtable.EDate > @starttime) AND (modifiedroutesubtable.CDate <= @starttime) GROUP BY productsdata.ProductName, branchdata.BranchName, productsdata.sno");
                    cmd.Parameters.Add("@TripID", routeid);
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@itype", routeitype);
                    DataTable dtDispProducts = vdm.SelectQuery(cmd).Tables[0];
                    //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty),2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteID) and (indents.IndentType = @IndentType) GROUP BY productsdata.ProductName");
                    //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS TotalQty, productsdata.sno, indents_subtable.UnitCost, productsdata.ProductName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno WHERE (indents.I_date between @d1 AND  @d2) AND (indents.IndentType = @IndentType) AND (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName ORDER BY TotalQty");
                    //cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    //cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    //cmd.Parameters.Add("@RouteID", RouteId);
                    //cmd.Parameters.Add("@IndentType", IndentType);
                    //DataTable dtDispProducts = new DataTable();

                    cmd = new MySqlCommand("SELECT ROUND(SUM(offer_indents_sub.offer_indent_qty), 2) AS TotalQty, productsdata.sno, productsdata.ProductName FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType, I_modified_by FROM offer_indents WHERE (indent_date BETWEEN @d1 AND @d2) AND (IndentType = @IndentType)) offerindent ON branchroutesubtable.BranchID = offerindent.agent_id INNER JOIN offer_indents_sub ON offerindent.idoffer_indents = offer_indents_sub.idoffer_indents INNER JOIN productsdata ON offer_indents_sub.product_id = productsdata.sno WHERE (dispatch.sno = @RouteID) GROUP BY productsdata.ProductName");
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                    cmd.Parameters.Add("@RouteID", RouteId);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    DataTable dtOfferDispProducts = vdm.SelectQuery(cmd).Tables[0];

                    foreach (DataRow drDisp in dtDispProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTotalProducts.Rows)
                        {
                            if (drDisp["Product_sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drDisp["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["TotalQty"].ToString(), out qtycpy);
                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }

                    foreach (DataRow drDisp in dtOfferDispProducts.Rows)
                    {
                        foreach (DataRow drtotprod in dtTotalProducts.Rows)
                        {
                            if (drDisp["sno"].ToString() == drtotprod["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drDisp["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drtotprod["TotalQty"].ToString(), out qtycpy);
                                float totalqty = qty + qtycpy;
                                //float total = 0;
                                //float.TryParse(drprdt["TotalQty"].ToString(), out total);
                                //float totqty = total + totalqty;
                                drtotprod["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }
                    List<dispProducts> Displist = new List<dispProducts>();
                    int i = 1;
                    //dtTotalProducts.DefaultView.Sort = "TotalQty desc";
                    //dtTotalProducts = dtTotalProducts.DefaultView.ToTable(true);
                    context.Session["dtTripSubData"] = "";
                    foreach (DataRow dr in dtTotalProducts.Rows)
                    {
                        foreach (DataRow drsub in dtsubtrip.Rows)
                        {
                            if (dr["sno"].ToString() == drsub["ProductId"].ToString())
                            {
                                dispProducts getdispProducts = new dispProducts();
                                getdispProducts.sno = i++.ToString();
                                getdispProducts.ProductCode = dr["ProductName"].ToString();
                                getdispProducts.Productsno = dr["sno"].ToString();
                                getdispProducts.Qty = dr["TotalQty"].ToString();
                                float Qty = 0;
                                float.TryParse(dr["TotalQty"].ToString(), out Qty);
                                float subdataQty = 0;
                                float.TryParse(drsub["subdataQty"].ToString(), out subdataQty);
                                float DeliverQty = 0;
                                if (DispType == "SO")
                                {
                                }
                                else
                                {
                                    float.TryParse(drsub["DeliverQty"].ToString(), out DeliverQty);
                                }
                                float RemainQty = subdataQty - DeliverQty;
                                RemainQty = RemainQty - Qty;
                                getdispProducts.RemainQty = RemainQty.ToString();
                                string DispQty = "";
                                DispQty = dr["TotalQty"].ToString();
                                if (DispQty == "0")
                                {
                                    DispQty = "";
                                }
                                getdispProducts.DispQty = DispQty;
                                if (subdataQty != 0 || Qty != 0)
                                {
                                    Displist.Add(getdispProducts);
                                }
                            }
                        }
                    }
                    string response = GetJson(Displist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        public class dispProducts
        {
            public string sno { get; set; }
            public string ProductCode { get; set; }
            public string RemainQty { get; set; }
            public string Productsno { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
        }
        private void GetCsodispatchRoutes(HttpContext context)
        {
            try
            {
                if (context.Session["CsoNo"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                    //cmd = new MySqlCommand("SELECT RouteName, Sno FROM branchroutes WHERE (BranchID = @BranchID) GROUP BY RouteName");
                    //cmd = new MySqlCommand("SELECT DispName, sno FROM dispatch WHERE (Branch_Id = @Branch_Id) GROUP BY DispName");
                    DataTable dtBranch = new DataTable();
                    if (context.Session["dtBranch"] == null)
                    {
                        string BIDD = context.Session["CsoNo"].ToString();
                        cmd = new MySqlCommand("SELECT DispName, sno FROM dispatch WHERE (Branch_Id = @Branch_Id) and (DispMode is NULL) GROUP BY DispName");
                        cmd.Parameters.Add("@Branch_Id", context.Session["CsoNo"].ToString());
                        dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        dtBranch = (DataTable)context.Session["dtBranch"];
                    }
                    List<Route> Routelist = new List<Route>();
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Route b = new Route() { rid = dr["sno"].ToString(), RouteName = dr["DispName"].ToString() };
                        Routelist.Add(b);
                    }
                    string response = GetJson(Routelist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetSOEmployeeNames(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtEmployee = new DataTable();
                cmd = new MySqlCommand("SELECT Sno, UserName FROM empmanage WHERE (Branch = @BranchID) and (Leveltype='Opperations') AND (flag <> 0)");
                cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                dtEmployee = vdm.SelectQuery(cmd).Tables[0];
                List<Employee> Employeelist = new List<Employee>();
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    Employee b = new Employee() { Sno = dr["Sno"].ToString(), UserName = dr["UserName"].ToString() };
                    Employeelist.Add(b);
                }
                string response = GetJson(Employeelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class Employee
        {
            public string Sno { get; set; }
            public string UserName { get; set; }
        }
        private void GetIndentType(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteId = "";
                if (context.Request["RouteId"] != "")
                {
                    RouteId = context.Request["RouteId"];
                }
                else
                {
                    RouteId = context.Session["RouteId"].ToString();
                }

                List<IndentClas> Indentlist = new List<IndentClas>();
                string leveltype = context.Session["Permissions"].ToString();
                if (leveltype == "Dispatcher" || leveltype == "SODispatcher")
                {
                    cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.sno = @sno) group by dispatch_sub.IndentType");
                    cmd.Parameters.Add("@sno", RouteId);
                    DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtIndentType.Rows)
                    {
                        string indent = dr["IndentType"].ToString();
                        if (indent != "")
                        {
                            IndentClas getIndentType = new IndentClas();
                            getIndentType.IndentType = dr["IndentType"].ToString();
                            Indentlist.Add(getIndentType);
                        }
                    }
                }
                else
                {
                    if (context.Session["routearray"] != null)
                    {
                        string[] routearray = (string[])context.Session["routearray"];

                        if (routearray != null)
                        {
                            if (routearray.Length > 1)
                            {

                                cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.Route_id = @Route_id) group by dispatch_sub.IndentType");
                                cmd.Parameters.Add("@Route_id", RouteId);
                                DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                                foreach (DataRow dr in dtIndentType.Rows)
                                {
                                    string indent = dr["IndentType"].ToString();
                                    if (indent != "")
                                    {
                                        IndentClas getIndentType = new IndentClas();
                                        getIndentType.IndentType = dr["IndentType"].ToString();
                                        Indentlist.Add(getIndentType);
                                    }
                                }
                            }
                        }
                        else
                        {
                            cmd = new MySqlCommand("SELECT dispatch_sub.IndentType FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch.sno = @dispatchSno) group by dispatch_sub.IndentType");
                            cmd.Parameters.Add("@dispatchSno", RouteId);
                            DataTable dtIndentType = vdm.SelectQuery(cmd).Tables[0];
                            foreach (DataRow dr in dtIndentType.Rows)
                            {
                                IndentClas getIndentType = new IndentClas();
                                getIndentType.IndentType = dr["IndentType"].ToString();
                                Indentlist.Add(getIndentType);
                            }
                        }
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class IndentClas
        {
            public string IndentType { get; set; }
        }

        private void GetDispatchBranch(HttpContext context)
        {
            try
            {
                if (context.Session["RouteId"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    vdm = new VehicleDBMgr();
                     string DispType = context.Session["DispType"].ToString();
                     if (DispType == "YES")
                     {
                         cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchdata.flag = @flag) and (branchmappingtable.SuperBranch=@BranchID)GROUP BY branchdata.BranchName");
                         cmd.Parameters.Add("@flag", 1);
                         cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());
                     }
                     else
                     {
                         cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno WHERE (dispatch_sub.dispatch_sno = @dispatch_sno) GROUP BY branchdata.BranchName");
                         //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN  branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (triproutes.Tripdata_sno = @TripId) GROUP BY branchdata.BranchName");
                         //cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                         cmd.Parameters.Add("@dispatch_sno", context.Session["RouteId"].ToString());
                     }
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    List<Branch> brnch = new List<Branch>();
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                        brnch.Add(b);
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        private void GetDispatchAgents(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string[] routearray = (string[])context.Session["routearray"];
                List<Route> Routelist = new List<Route>();
                if (routearray.Length > 1)
                {
                    string querycond = "";
                    for (int i = 0; i < routearray.Length; i++)
                    {
                        if (routearray[i] != "")
                        {
                            querycond += " dispatch.sno=" + routearray[i] + " or";
                        }
                    }
                    querycond = querycond.Substring(0, querycond.Length - 3);
                    string dd = context.Session["BranchSno"].ToString();
                    cmd = new MySqlCommand("SELECT branchroutes.RouteName, branchroutes.Sno FROM branchroutes INNER JOIN branchdata ON branchroutes.BranchID = branchdata.sno INNER JOIN branchdata branchdata_1 ON branchroutes.BranchID = branchdata_1.sno WHERE  (branchdata_1.SalesOfficeID = @BranchID) OR  (branchdata.sno = @BID) and (branchroutes.flag=1)");
                    //cmd = new MySqlCommand("SELECT branchroutes.RouteName, branchroutes.Sno  FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutes ON dispatch.Route_id = branchroutes.Sno WHERE (triproutes.Tripdata_sno = @TripId) and (" + querycond + ")  GROUP BY branchroutes.RouteName");
                    cmd.Parameters.Add("@BranchID", context.Session["BranchSno"].ToString());
                    cmd.Parameters.Add("@BID", context.Session["BranchSno"].ToString());
                    //  cmd.Parameters.Add("@dispatchsno", querycond);
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Route b = new Route() { rid = dr["Sno"].ToString(), RouteName = dr["RouteName"].ToString() };
                        Routelist.Add(b);
                    }
                    string response = GetJson(Routelist);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN  branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (triproutes.Tripdata_sno = @TripId) GROUP BY branchdata.BranchName");
                    cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    List<Branch> brnch = new List<Branch>();
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                        brnch.Add(b);
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetIndentStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                if (context.Session["RouteId"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string RouteId = "";
                    if (context.Request["RouteId"] != "")
                    {
                        RouteId = context.Request["RouteId"];
                    }
                    else
                    {
                        RouteId = context.Session["RouteId"].ToString();
                    }
                    List<BranchStatus> BList = new List<BranchStatus>();
                    DataTable dtbranches = new DataTable();
                    string[] routearray = (string[])context.Session["routearray"];
                    List<Route> Routelist = new List<Route>();
                    if (routearray.Length > 1)
                    {
                        cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, indents.IndentNo, indents.I_date FROM  branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (indents.I_date between @d1 AND  @d2)");
                        cmd.Parameters.Add("@RouteId", RouteId);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        dtbranches = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {

                        cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName, indents.IndentNo FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (triproutes.Tripdata_sno = @TripId) AND (dispatch_sub.dispatch_sno = @dispatch_sno) AND (indents.I_date between @d1 AND  @d2) GROUP BY branchdata.BranchName");
                        //cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, indents.IndentNo, indents.I_date FROM  branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (indents.I_date > @d1) AND (indents.I_date < @d2)");
                        cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        cmd.Parameters.Add("@dispatch_sno", RouteId);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        dtbranches = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (dtbranches.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbranches.Rows)
                        {
                            BranchStatus b = new BranchStatus() { bid = dr["sno"].ToString(), BName = dr["BranchName"].ToString() };
                            BList.Add(b);
                        }
                        string response = GetJson(BList);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        class BranchStatus
        {
            public string bid { get; set; }
            public string BName { get; set; }
        }
        private void GetProductIndent(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string ProductId = context.Request["ProductSno"];
                cmd = new MySqlCommand("SELECT tripsubdata.Qty FROM triproutes INNER JOIN tripsubdata ON triproutes.Tripdata_sno = tripsubdata.Tripdata_sno where triproutes.RouteID=@RouteID and tripsubdata.ProductId=@ProductId");
                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                cmd.Parameters.Add("@ProductId", ProductId);
                DataTable dtqty = vdm.SelectQuery(cmd).Tables[0];
                if (dtqty.Rows.Count > 0)
                {
                    string Indentqty = dtqty.Rows[0]["Qty"].ToString();
                    string response = GetJson(Indentqty);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void CollectionReports(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                string Permissions = context.Request["Permissions"];
                string RouteId = context.Session["RouteId"].ToString();
                //cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.AmountPaid FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON collections.Branchid = indents.Branch_id WHERE (branchroutes.Sno = @RouteId) AND (collections.PaidDate >= @starttime) AND (collections.PaidDate < @endtime) GROUP BY branchdata.BranchName");
                cmd = new MySqlCommand("SELECT indents.Branch_id, branchdata.BranchName, collections.AmountPaid, branchroutes.Sno FROM indents INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN collections ON collections.Branchid = indents.Branch_id INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id WHERE (collections.PaidDate between @d1 and @d2) AND (dispatch_sub.dispatch_sno = @dispatch_sno) GROUP BY branchdata.BranchName, branchroutes.Sno, dispatch_sub.dispatch_sno");
                cmd.Parameters.Add("@dispatch_sno", RouteId);
                //cmd.Parameters.Add("@EmpSno", 27);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                DataTable dtColectionBranchs = vdm.SelectQuery(cmd).Tables[0];
                List<BranchColection> BranchColectionlist = new List<BranchColection>();
                if (dtColectionBranchs.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtColectionBranchs.Rows)
                    {
                        BranchColection GetBranchColection = new BranchColection();
                        GetBranchColection.Sno = i++.ToString();
                        GetBranchColection.BranchName = dr["BranchName"].ToString();
                        GetBranchColection.BranchSno = dr["Branch_id"].ToString();
                        GetBranchColection.Amount = dr["AmountPaid"].ToString();
                        BranchColectionlist.Add(GetBranchColection);
                    }
                    string response = GetJson(BranchColectionlist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class BranchColection
        {
            public string Sno { get; set; }
            public string BranchName { get; set; }
            public string BranchSno { get; set; }
            public string Amount { get; set; }
        }
        private void getTodayDate(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                string bid = context.Request["bid"];
                cmd = new MySqlCommand("select I_date from Indents where Branch_id=@Branch_id and indents.I_date > @d1");
                cmd.Parameters.Add("@Branch_id", bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                DataTable indentDate = vdm.SelectQuery(cmd).Tables[0];
                DateTime date = (DateTime)indentDate.Rows[0]["I_date"];
                string IndentDate = date.ToString("dd/MM/yyyy");
                string Currentdate = GetTime(vdm.conn).ToString("dd/MM/yyyy");
                if (IndentDate == Currentdate)
                {
                    string IDate = IndentDate;
                    string response = GetJson(IDate);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public static DateTime GetTime(MySqlConnection conn)
        {

            DataSet ds = new DataSet();
            DateTime dt = DateTime.Now;
            MySqlCommand cmd = new MySqlCommand("SELECT NOW()");
            cmd.Connection = conn;
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            conn.Open();
            //cmd.ExecuteNonQuery();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(ds, "Table");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = (DateTime)ds.Tables[0].Rows[0][0];
            }
            return dt;

        }
        private void getReportAmount(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["UserSno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string EmpID = context.Session["UserSno"].ToString();
                    string SalesType = context.Session["Salestype"].ToString();
                    string DispatchSno = "";
                    if (SalesType == "Plant")
                    {
                        DispatchSno = context.Request["RouteID"];
                    }
                    else
                    {
                        DispatchSno = context.Session["RouteId"].ToString();
                    }
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    //cmd = new MySqlCommand("SELECT collections.AmountPaid,branchData.branchName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN collections ON branchdata.sno = collections.Branchid WHERE (branchroutes.Sno = @RouteId) and(collections.Paiddate >= @starttime) AND (collections.Paiddate  < @endtime) GROUP BY branchdata.BranchName, collections.AmountPaid");
                    cmd = new MySqlCommand(" SELECT collections.AmountPaid, branchdata.BranchName FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN collections ON branchdata.sno = collections.Branchid INNER JOIN dispatch_sub ON branchroutes.Sno = dispatch_sub.Route_id WHERE (collections.PaidDate >= @starttime) AND (collections.PaidDate < @endtime) AND (dispatch_sub.dispatch_sno= @dispatch_sno)GROUP BY branchdata.BranchName, collections.AmountPaid");
                    cmd.Parameters.Add("@dispatch_sno", DispatchSno);
                    cmd.Parameters.Add("@starttime", DateConverter.GetLowDate(ServerDateCurrentdate));
                    cmd.Parameters.Add("@endtime", DateConverter.GetHighDate(ServerDateCurrentdate));
                    DataTable dtAmount = vdm.SelectQuery(cmd).Tables[0];
                    double Amount = 0;
                    if (dtAmount.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtAmount.Rows)
                        {
                            float Deliverytotal = 0;
                            float.TryParse(dr["AmountPaid"].ToString(), out Deliverytotal);
                            Amount += Math.Round(Deliverytotal, 2);
                        }
                    }
                    string response = GetJson(Amount);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetInvReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["UserSno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string EmpID = context.Session["UserSno"].ToString();
                    string LevelType = context.Session["LevelType"].ToString();

                    List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                    if (LevelType == "Dispatcher")
                    {
                        //cmd = new MySqlCommand("SELECT invmaster.InvName,invmaster.sno,  SUM(invtransactions.TodayQty) AS Qty FROM  tripdata INNER JOIN invtransactions ON tripdata.Sno = invtransactions.TripID INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE (tripdata.Sno = @TripId)  GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                        cmd = new MySqlCommand("SELECT tripinvdata.invid, invmaster.InvName,tripinvdata.Qty, tripinvdata.Remaining FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @TripId)");
                        //cmd = new MySqlCommand("SELECT SUM(invtransactions.VQty) AS VQty, invtransactions.VarificationStatus, invtransactions.B_Inv_Sno, invmaster.InvName FROM invtransactions INNER JOIN tripdata ON invtransactions.VTripID = tripdata.Sno INNER JOIN invmaster ON invtransactions.B_Inv_Sno = invmaster.sno WHERE  (invtransactions.VarificationStatus = 'V') AND (tripdata.Sno = @tripdataSno) GROUP BY invmaster.InvName, invtransactions.VTripID ORDER BY invmaster.sno");
                        cmd.Parameters.Add("@TripId", context.Session["PlantDispSno"].ToString());
                        DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                        DataTable dtCInventory = vdm.SelectQuery(cmd).Tables[0];
                        if (dtInventory.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtInventory.Rows)
                            {
                                foreach (DataRow drC in dtCInventory.Rows)
                                {
                                    if (dr["invid"].ToString() == drC["invid"].ToString())
                                    {
                                        Inventoryclass GetInventory = new Inventoryclass();
                                        GetInventory.Sno = i++.ToString();
                                        GetInventory.InventoryName = dr["InvName"].ToString();
                                        GetInventory.InventorySno = dr["invid"].ToString();
                                        GetInventory.Qty = dr["Remaining"].ToString();
                                        GetInventory.DispQty = dr["Qty"].ToString();
                                        GetInventory.DelQty = drC["Qty"].ToString();
                                        InventoryList.Add(GetInventory);
                                    }
                                }
                            }
                            string response = GetJson(InventoryList);
                            context.Response.Write(response);
                        }
                    }
                    else if (LevelType == "SODispatcher")
                    {
                        cmd = new MySqlCommand("SELECT inventory_monitor.Qty, invmaster.InvName, inventory_monitor.Inv_Sno FROM inventory_monitor INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (inventory_monitor.BranchId = @BranchId)");
                        cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                        DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                        int i = 1;
                        foreach (DataRow dr in dtInventory.Rows)
                        {
                            Inventoryclass GetInventory = new Inventoryclass();
                            GetInventory.Sno = i++.ToString();
                            GetInventory.InventoryName = dr["InvName"].ToString();
                            GetInventory.InventorySno = dr["Inv_Sno"].ToString();
                            GetInventory.Qty = dr["Qty"].ToString();
                            GetInventory.DispQty = dr["Qty"].ToString();
                            GetInventory.DelQty = dr["Qty"].ToString();
                            InventoryList.Add(GetInventory);
                        }
                        string response = GetJson(InventoryList);
                        context.Response.Write(response);
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT tripinvdata.invid, invmaster.InvName,tripinvdata.Qty, tripinvdata.Remaining FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @TripId)");
                        cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                        DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];

                        DataTable dtCInventory = vdm.SelectQuery(cmd).Tables[0];
                        if (dtInventory.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtInventory.Rows)
                            {
                                foreach (DataRow drC in dtCInventory.Rows)
                                {
                                    if (dr["invid"].ToString() == drC["invid"].ToString())
                                    {
                                        Inventoryclass GetInventory = new Inventoryclass();
                                        GetInventory.Sno = i++.ToString();
                                        GetInventory.InventoryName = dr["InvName"].ToString();
                                        GetInventory.InventorySno = dr["invid"].ToString();
                                        GetInventory.Qty = dr["Remaining"].ToString();
                                        GetInventory.DispQty = dr["Qty"].ToString();
                                        GetInventory.DelQty = drC["Qty"].ToString();
                                        InventoryList.Add(GetInventory);
                                    }
                                }
                            }
                            string response = GetJson(InventoryList);
                            context.Response.Write(response);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void AddBranchProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string ProductSno = context.Request["ProductSno"];
                string Rate = context.Request["Rate"];
                string bid = context.Request["bid"];
                cmd = new MySqlCommand("update branchproducts set product_sno=@product_sno, flag=@flag where branch_sno=@branch_sno and userdata_sno=@userdata_sno");
                cmd.Parameters.AddWithValue("@branch_sno", bid);
                cmd.Parameters.AddWithValue("@product_sno", ProductSno);
                float UnitPrice = 0;
                cmd.Parameters.AddWithValue("@unitprice", UnitPrice);
                cmd.Parameters.AddWithValue("@flag", 1);
                cmd.Parameters.AddWithValue("@userdata_sno", 1);
                if (vdm.Update(cmd) == 0)
                {
                    cmd = new MySqlCommand("insert into branchproducts (branch_sno,product_sno,unitprice,flag,userdata_sno) values(@branch_sno,@product_sno,@unitprice,@flag,@userdata_sno)");
                    cmd.Parameters.AddWithValue("@branch_sno", bid);
                    cmd.Parameters.AddWithValue("@product_sno", ProductSno);
                    cmd.Parameters.AddWithValue("@unitprice", UnitPrice);
                    cmd.Parameters.AddWithValue("@flag", 1);
                    cmd.Parameters.AddWithValue("@userdata_sno", 1);
                    vdm.insert(cmd);
                }
            }
            catch
            {
            }
        }
        private void FillCategeoryname(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string username = context.Session["userdata_sno"].ToString();
                    cmd = new MySqlCommand("select sno,Categoryname from products_category where flag=@flag and userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    cmd.Parameters.Add("@flag", "1");
                    List<Categoryclass> Categorylist = new List<Categoryclass>();
                    foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                    {
                        Categoryclass getCategory = new Categoryclass();
                        getCategory.sno = dr["sno"].ToString();
                        getCategory.categoryname = dr["Categoryname"].ToString();
                        Categorylist.Add(getCategory);
                    }
                    if (context.Session["getbranchcategorynames"] == null)
                    {
                        cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                        cmd.Parameters.Add("@username", username);
                        DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["getbranchcategorynames"] = dt;
                    }
                    //if (context.Session["getproductsnames"] == null)
                    //{
                    //    cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName FROM products_subcategory RIGHT OUTER JOIN productsdata ON products_subcategory.sno = productsdata.SubCat_sno WHERE (products_subcategory.Flag <> 0) AND productsdata.UserData_sno=@username");
                    //    //cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username AND products_subcategory.userdata_sno=@username AND productsdata.UserData_sno=@username");
                    //    cmd.Parameters.Add("@username", username);
                    //    DataTable dt1 = vdm.SelectQuery(cmd).Tables[0];
                    //    context.Session["getproductsnames"] = dt1;
                    //}
                    string response = GetJson(Categorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Categoryclass
        {
            public string sno { set; get; }
            public string categoryname { set; get; }
        }
        private void get_product_subcategory_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<subCategoryclass> subCategorylist = new List<subCategoryclass>();
                string username = context.Session["userdata_sno"].ToString();
                string catgryname = context.Request["cmbcatgryname"];
                DataTable categorys = new DataTable();
                if (context.Session["getbranchcategorynames"] == null)
                {
                    cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    categorys = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["getbranchcategorynames"] = categorys;
                }
                else
                {
                    categorys = (DataTable)context.Session["getbranchcategorynames"];
                }
                DataTable subcatgrynames = categorys.DefaultView.ToTable(true, "category_sno", "SubCatName", "sno");
                DataRow[] subcatgry = subcatgrynames.Select("category_sno=" + catgryname + "");
                foreach (DataRow dr in subcatgry)
                {
                    subCategoryclass GetsubCategory = new subCategoryclass();
                    GetsubCategory.sno = dr["sno"].ToString();
                    GetsubCategory.subcategorynames = dr["SubCatName"].ToString();
                    subCategorylist.Add(GetsubCategory);
                }
                if (subCategorylist != null)
                {
                    string response = GetJson(subCategorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        class subCategoryclass
        {
            public string sno { set; get; }
            public string subcategorynames { set; get; }
        }
        private void get_products_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<ProductNames> ProductNamesList = new List<ProductNames>();
                string username = context.Session["userdata_sno"].ToString();
                string subcatname = context.Request["cmbsubcatgryname"];
                DataTable subcategorys = new DataTable();
                if (context.Session["getproductsnames"] == null)
                {
                    cmd = new MySqlCommand("SELECT productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno LEFT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno WHERE (products_subcategory.Flag <> 0) AND (productsdata.UserData_sno = @username) AND (branchproducts.branch_sno = @BranchID)");
                    //cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName FROM products_subcategory RIGHT OUTER JOIN productsdata ON products_subcategory.sno = productsdata.SubCat_sno WHERE (products_subcategory.Flag <> 0) AND productsdata.UserData_sno=@username");
                    cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                    cmd.Parameters.Add("@username", username);
                    DataTable dt1 = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["getproductsnames"] = dt1;
                    subcategorys = dt1;
                }
                else
                {
                    subcategorys = (DataTable)context.Session["getproductsnames"];
                }
                DataTable productnames = subcategorys.DefaultView.ToTable(true, "SubCat_sno", "ProductName", "sno");
                DataRow[] products = productnames.Select("SubCat_sno=" + subcatname + "");
                foreach (DataRow dr in products)
                {
                    ProductNames GetProduct = new ProductNames();
                    GetProduct.productName = dr["ProductName"].ToString();
                    GetProduct.Sno = dr["sno"].ToString();
                    ProductNamesList.Add(GetProduct);
                }
                if (ProductNamesList != null)
                {
                    string response = GetJson(ProductNamesList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public class ProductNames
        {
            public string productName { get; set; }
            public string Qty { get; set; }
            public string Sno { get; set; }
        }
        private void getBranchLeakeges(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["bid"];
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    List<Orderclass> OrderList = new List<Orderclass>();
                    string SalesType = context.Session["Salestype"].ToString();
                    if (SalesType == "Plant")
                    {
                        string RouteID = context.Request["RouteID"];
                        string DispDate = context.Session["DispDate"].ToString();
                        DateTime dtdispDate = Convert.ToDateTime(DispDate);
                        //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status, indents_subtable.Cost as unitprice, productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno) AND (indents_subtable.Status <> 'Delivered') and (indents_subtable.Status <> 'Cancelled' ) AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                        cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) group By productsdata.ProductName ");
                        cmd.Parameters.Add("@UserName", Username);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                        cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                        DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                        //cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteId) AND (indents_subtable.Status <> 'Delivered') GROUP BY productsdata.ProductName, branchroutes.Sno");
                        //cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno ON dispatch_sub.dispatch_sno = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (indents_subtable.Status <> 'Delivered') AND (dispatch.sno = @dispatchsno)GROUP BY productsdata.ProductName");
                        cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.RouteName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (indents.I_date between @d1 AND  @d2) GROUP BY productsdata.ProductName");
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                        cmd.Parameters.Add("@dispatchsno", RouteID);
                        DataTable dtDailyIndent = vdm.SelectQuery(cmd).Tables[0];
                        //cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, branchproducts.manufact_remaining_qty as RemainQty FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchmappingtable.SuperBranch = @SuperBranch)  GROUP BY branchproducts.product_sno, productsdata.ProductName ");

                        cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, ROUND(tripsubdata.Qty, 2) AS Qty FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.RouteID = @RouteID) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)");
                        cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                        cmd.Parameters.Add("@EmpId", context.Session["UserSno"].ToString());
                        DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["Delivers"] = dtBranch;
                        int i = 1;
                        foreach (DataRow dr in dtBranch.Rows)
                        {
                            int Branchprdtsno = 0;
                            int.TryParse(dr["Product_sno"].ToString(), out Branchprdtsno);
                            foreach (DataRow remainingdr in dtProducts.Rows)
                            {
                                int ProductId = 0;
                                int.TryParse(remainingdr["ProductId"].ToString(), out ProductId);
                                if (Branchprdtsno == ProductId)
                                {
                                    Orderclass getOrderValue = new Orderclass();
                                    getOrderValue.sno = i++.ToString();
                                    getOrderValue.HdnSno = dr["Sno"].ToString();
                                    getOrderValue.ProductCode = dr["ProductName"].ToString();
                                    getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                    int prodsno = 0;
                                    int.TryParse(dr["Product_sno"].ToString(), out prodsno);
                                    getOrderValue.Productsno = prodsno;
                                    float qty = 0;
                                    float.TryParse(dr["unitQty"].ToString(), out qty);
                                    getOrderValue.Qty = Math.Round(qty, 2);

                                    getOrderValue.Rate = (float)dr["UnitCost"];
                                    string LeakQty = dr["LeakQty"].ToString();
                                    float Dqty = 0;
                                    if (LeakQty != "")
                                    {
                                        float Leak = 0;
                                        float.TryParse(LeakQty, out Leak);
                                        getOrderValue.LeakQty = Math.Round(Leak, 2);

                                        float.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                                        getOrderValue.DQty = Math.Round(Dqty, 2); ;
                                    }
                                    else
                                    {
                                        getOrderValue.LeakQty = 0;
                                        getOrderValue.DQty = Math.Round(qty, 2);
                                    }
                                    getOrderValue.Status = dr["Status"].ToString();
                                    float Rqty = 0;
                                    float.TryParse(remainingdr["Qty"].ToString(), out Rqty);
                                    //float.TryParse(dr["Qty"].ToString(), out Rqty);
                                    getOrderValue.RQty = Rqty;
                                    double total = Dqty * (float)dr["UnitCost"];
                                    getOrderValue.Total = Math.Round(total, 2);
                                    foreach (DataRow drDaily in dtDailyIndent.Rows)
                                    {
                                        int ProSno = 0;
                                        int.TryParse(drDaily["Product_sno"].ToString(), out ProSno);
                                        if (ProSno == Branchprdtsno)
                                        {
                                            float Iqty = 0;
                                            float.TryParse(drDaily["Iqty"].ToString(), out Iqty);
                                            float trqty = Iqty - Dqty; ;
                                            getOrderValue.TRQty = Math.Round(trqty, 2);
                                        }
                                    }
                                    getOrderValue.orderunitRate = (float)dr["UnitCost"];
                                    OrderList.Add(getOrderValue);
                                }
                            }
                        }
                    }
                    else
                    {
                        string DispDate = context.Session["I_Date"].ToString();
                        DateTime dtdispDate = Convert.ToDateTime(DispDate);
                        cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno,indents_subtable.LeakQty, indents_subtable.unitQty,indents_subtable.UnitCost,indents_subtable.DeliveryQty, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) group By productsdata.ProductName");

                        //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno,indents_subtable.LeakQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno,sum(indents_subtable.UnitCost*indents_subtable.unitQty) as Total, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                        cmd.Parameters.Add("@UserName", Username);
                        //cmd.Parameters.Add("@IndentNo", IndentNo);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                        cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                        DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["Delivers"] = dtBranch;
                        int i = 1;
                        foreach (DataRow dr in dtBranch.Rows)
                        {
                            Orderclass getOrderValue = new Orderclass();
                            getOrderValue.sno = i++.ToString();
                            getOrderValue.HdnSno = dr["Sno"].ToString();
                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                            int prodsno = 0;
                            int.TryParse(dr["Product_sno"].ToString(), out prodsno);
                            getOrderValue.Productsno = prodsno;
                            double qty = 0;
                            double.TryParse(dr["unitQty"].ToString(), out qty);
                            getOrderValue.Qty = Math.Round(qty, 2);
                            getOrderValue.Rate = (float)dr["UnitCost"];
                            string LeakQty = dr["LeakQty"].ToString();
                            if (LeakQty != "")
                            {
                                float Leak = 0;
                                float.TryParse(LeakQty, out Leak);
                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                            }
                            else
                            {
                                getOrderValue.LeakQty = 0;
                            }
                            getOrderValue.Status = dr["Status"].ToString();
                            double Dqty = 0;
                            double.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                            double total = Dqty * (float)dr["UnitCost"];
                            getOrderValue.Total = Math.Round(total, 2);
                            float DelQty = 0;
                            float.TryParse(dr["DeliveryQty"].ToString(), out DelQty);
                            getOrderValue.DQty = Math.Round(DelQty, 2);
                            getOrderValue.orderunitRate = (float)dr["UnitCost"];
                            OrderList.Add(getOrderValue);
                        }
                    }
                    string respnceString = GetJson(OrderList);
                    context.Response.Write(respnceString);
                }
            }
            catch
            {
            }
        }

        private void GetInventoryNames(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Inventoryclass> InventoryList = new List<Inventoryclass>();
                DataTable dtInvMaster = new DataTable();
                if (context.Session["dtInvMaster"] == null)
                {
                    cmd = new MySqlCommand("SELECT InvName,sno from invmaster");
                    dtInvMaster = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    dtInvMaster = (DataTable)context.Session["dtInvMaster"];
                }
                if (dtInvMaster.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtInvMaster.Rows)
                    {
                        Inventoryclass GetInventory = new Inventoryclass();
                        GetInventory.Sno = i++.ToString();
                        GetInventory.InventoryName = dr["InvName"].ToString();
                        GetInventory.InventorySno = dr["sno"].ToString();
                        GetInventory.Qty = "";
                        InventoryList.Add(GetInventory);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetDeliverInventory(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["bid"];
                string DairyStatus = context.Request["DairyStatus"];
                List<Inventoryclass> InventoryList = new List<Inventoryclass>();
               // //// cmd = new MySqlCommand("SELECT invmaster.InvName,invmaster.sno, invtransactions.Qty, invtransactions.TodayQty, inventory_monitor.Qty AS BranchQty FROM invmaster INNER JOIN invtransactions ON invmaster.sno = invtransactions.B_Inv_Sno INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno AND invtransactions.BranchId = inventory_monitor.BranchId WHERE (invtransactions.Status = @Status) AND (invtransactions.TripID = @TripID) AND (invtransactions.BranchId = @BranchId) GROUP BY invmaster.InvName, invtransactions.Status ORDER BY invmaster.sno");
               ////  cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, invtransactions.Qty,invtransactions.TodayQty, inventory_monitor.Qty AS BranchQty FROM invmaster INNER JOIN invtransactions ON invmaster.sno = invtransactions.B_Inv_Sno INNER JOIN inventory_monitor ON invtransactions.BranchId = inventory_monitor.BranchId WHERE (inventory_monitor.BranchId = @BranchId) AND (invtransactions.Status =@Status)  AND (invtransactions.TripID = @TripID)GROUP BY invmaster.InvName,invtransactions.Status");
                if (DairyStatus == "Delivers")
                {
                    cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty AS BranchQty, invtransactions12.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.FromTran = @FromTran) AND (invtransactions12.ToTran = @ToTrans) AND (invtransactions12.TransType = @TransType) AND (inventory_monitor.BranchId = @BranchID)GROUP BY invmaster.InvName ORDER BY invmaster.sno ");
                    //cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty AS BranchQty, invtransactions12.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno INNER JOIN  invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno AND inventory_monitor.BranchId = invtransactions12.FromTran WHERE (invtransactions12.FromTran = @FromTran) and (invtransactions12.ToTran = @ToTrans) AND (invtransactions12.TransType = @TransType) AND (inventory_monitor.BranchId = @BranchID) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                    cmd.Parameters.Add("@TransType", "2");
                    cmd.Parameters.Add("@FromTran", context.Session["TripdataSno"].ToString());
                    cmd.Parameters.Add("@ToTrans", BranchID);
                }
                else
                {
                   // cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty AS BranchQty, invtransactions12.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.FromTran = @FromTran) AND (invtransactions12.ToTran = @ToTrans) AND (invtransactions12.TransType = @TransType) AND (inventory_monitor.BranchId = @BranchID)GROUP BY invmaster.InvName ORDER BY invmaster.sno ");
                    cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty AS BranchQty, invtransactions12.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno INNER JOIN invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno WHERE (invtransactions12.FromTran = @FromTran) AND (invtransactions12.ToTran = @ToTrans) AND (invtransactions12.TransType = @TransType) AND (inventory_monitor.BranchId = @BranchID) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                    cmd.Parameters.Add("@TransType", "3");
                    cmd.Parameters.Add("@FromTran", BranchID);
                    cmd.Parameters.Add("@ToTrans", context.Session["TripdataSno"].ToString());
                }
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                if (dtPrevInventory.Rows.Count > 0)
                {

                    dtPrevInventory.DefaultView.Sort = "sno ASC";
                    dtPrevInventory = dtPrevInventory.DefaultView.ToTable(true);
                    context.Session["dtPrevInventory"] = dtPrevInventory;
                    int i = 1;
                    foreach (DataRow dr in dtPrevInventory.Rows)
                    {
                        Inventoryclass Inventoryget = new Inventoryclass();
                        Inventoryget.Sno = i++.ToString();
                        Inventoryget.InventorySno = dr["sno"].ToString();
                        Inventoryget.InventoryName = dr["InvName"].ToString();
                        if (DairyStatus == "Delivers")
                        {
                            int BranchQty = 0;
                            int.TryParse(dr["BranchQty"].ToString(), out BranchQty);
                            int Qty = 0;
                            int.TryParse(dr["Qty"].ToString(), out Qty);
                            int ToadayQty = BranchQty - Qty;
                            Inventoryget.Qty = ToadayQty.ToString();
                            Inventoryget.ToadayQty = dr["Qty"].ToString();
                        }
                        else
                        {
                            int BranchQty = 0;
                            int.TryParse(dr["BranchQty"].ToString(), out BranchQty);
                            int Qty = 0;
                            int.TryParse(dr["Qty"].ToString(), out Qty);
                            int ToadayQty = BranchQty + Qty;
                            Inventoryget.Qty = ToadayQty.ToString();
                            Inventoryget.ToadayQty = dr["Qty"].ToString();
                        }
                        InventoryList.Add(Inventoryget);
                    }
                    string response = GetJson(InventoryList);
                    context.Response.Write(response);
                }
                else
                {
                    context.Session["dtPrevInventory"] = null;
                    cmd = new MySqlCommand("SELECT invmaster.InvName, inventory_monitor.Qty, inventory_monitor.Sno, inventory_monitor.Inv_Sno FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno WHERE (inventory_monitor.BranchId = @BranchId)");
                    cmd.Parameters.Add("@BranchId", BranchID);
                    DataTable dtInventory = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtAgentInventory = new DataTable();
                    if (dtInventory.Rows.Count == 0)
                    {
                        if (context.Session["dtInventory"] == null)
                        {
                            cmd = new MySqlCommand("SELECT sno,InvName FROM invmaster");
                            dtAgentInventory = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            dtAgentInventory = (DataTable)context.Session["dtInventory"];
                        }
                        int i = 1;
                        foreach (DataRow dr in dtAgentInventory.Rows)
                        {
                            Inventoryclass Inventoryget = new Inventoryclass();
                            Inventoryget.Sno = i++.ToString();
                            Inventoryget.InventorySno = dr["sno"].ToString();
                            Inventoryget.InventoryName = dr["InvName"].ToString();
                            Inventoryget.Qty = "0";
                            Inventoryget.ToadayQty = "";
                            InventoryList.Add(Inventoryget);
                        }
                        string response = GetJson(InventoryList);
                        context.Response.Write(response);
                    }
                    else
                    {
                        int i = 1;
                        foreach (DataRow dr in dtInventory.Rows)
                        {
                            Inventoryclass GetInventory = new Inventoryclass();
                            GetInventory.Sno = i++.ToString();
                            GetInventory.InventoryName = dr["InvName"].ToString();
                            GetInventory.InventorySno = dr["Inv_Sno"].ToString();
                            GetInventory.Qty = dr["Qty"].ToString();
                            GetInventory.ToadayQty = "";
                            InventoryList.Add(GetInventory);
                        }
                        string response = GetJson(InventoryList);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        public class Inventoryclass
        {
            public string Sno { get; set; }
            public string InventoryName { get; set; }
            public string InventorySno { get; set; }
            public string Qty { get; set; }
            public string DispQty { get; set; }
            public string DelQty { get; set; }
            public string ToadayQty { get; set; }
        }
        private void GetProductNamechange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Sno = context.Request["ProductSno"];
                string BranchID = context.Request["BranchID"];
                List<ProductUnit> ProductList = new List<ProductUnit>();
                cmd = new MySqlCommand("SELECT branchproducts.unitprice, branchproducts.product_sno, productsdata.Qty, productsdata.Units FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) and (branchproducts.product_sno=@sno) ");
                cmd.Parameters.Add("@sno", Sno);
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtBranchProduct = vdm.SelectQuery(cmd).Tables[0];
                string AunitPrice = "0";
                if (dtBranchProduct.Rows.Count > 0)
                {
                    AunitPrice = dtBranchProduct.Rows[0]["unitprice"].ToString();
                }
                if (AunitPrice == "0")
                {
                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,productsdata.Qty, productsdata.Units, branchproducts.product_sno, branchproducts.unitprice AS Bunitprice , productsdata.ProductName FROM productsdata INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch WHERE (branchmappingtable.SubBranch = @BranchID) AND (branchproducts.product_sno = @Sno)");
                    cmd.Parameters.Add("@sno", Sno);
                    cmd.Parameters.Add("@BranchID", BranchID);
                    DataTable dtProduct = vdm.SelectQuery(cmd).Tables[0];
                    ProductUnit GetProduct = new ProductUnit();
                    GetProduct.UnitPrice = dtProduct.Rows[0]["UnitPrice"].ToString();
                    GetProduct.Unitqty = dtProduct.Rows[0]["Qty"].ToString();
                    GetProduct.Units = dtProduct.Rows[0]["Units"].ToString();
                    string BranchUnitPrice = dtProduct.Rows[0]["BUnitPrice"].ToString();
                    float Rate = 0;
                    if (BranchUnitPrice != "0")
                    {
                        Rate = (float)dtProduct.Rows[0]["BUnitPrice"];
                    }
                    else
                    {
                        Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                    }
                    //float Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                    float Unitqty = (float)dtProduct.Rows[0]["Qty"];
                    float TotalRate = 0;
                    TotalRate = Rate;
                    //if (dtProduct.Rows[0]["Units"].ToString() == "ml")
                    //{
                    //    TotalRate = Rate;
                    //}
                    //if (dtProduct.Rows[0]["Units"].ToString() == "ltr")
                    //{
                    //    TotalRate = Rate;
                    //}
                    //if (dtProduct.Rows[0]["Units"].ToString() == "gms")
                    //{
                    //}
                    //if (dtProduct.Rows[0]["Units"].ToString() == "kgs")
                    //{
                    //    TotalRate = Rate;
                    //}
                    if (dtProduct.Rows[0]["Units"].ToString() == "ml" || dtProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        GetProduct.Desciption = "Ltrs";
                    }
                    else
                    {
                        if (dtProduct.Rows[0]["Units"].ToString() == "Nos")
                        {
                            GetProduct.Desciption = "Nos";
                        }
                        else
                        {
                            GetProduct.Desciption = "Kgs";
                        }
                    }
                    //getOrderValue.Rate = (float)Rate;
                    GetProduct.orderunitRate = (float)TotalRate;
                    ProductList.Add(GetProduct);
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
                else
                {
                    ProductUnit GetProduct = new ProductUnit();
                    GetProduct.UnitPrice = dtBranchProduct.Rows[0]["UnitPrice"].ToString();
                    GetProduct.Unitqty = dtBranchProduct.Rows[0]["Qty"].ToString();
                    GetProduct.Units = dtBranchProduct.Rows[0]["Units"].ToString();
                    float Rate = (float)dtBranchProduct.Rows[0]["UnitPrice"];
                    float Unitqty = (float)dtBranchProduct.Rows[0]["Qty"];
                    float TotalRate = 0;
                    TotalRate = Rate;
                    //if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml")
                    //{
                    //    TotalRate = Rate;
                    //}
                    //if (dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                    //{
                    //    TotalRate = Rate;
                    //}
                    //if (dtBranchProduct.Rows[0]["Units"].ToString() == "gms")
                    //{
                    //}
                    //if (dtBranchProduct.Rows[0]["Units"].ToString() == "kgs")
                    //{
                    //    TotalRate = Rate;
                    //}
                    if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml" || dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                    {
                        GetProduct.Desciption = "Ltrs";
                    }
                    else
                    {
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "Nos")
                        {
                            GetProduct.Desciption = "Nos";
                        }
                        else
                        {
                            GetProduct.Desciption = "Kgs";
                        }
                    }
                    //getOrderValue.Rate = (float)Rate;
                    GetProduct.orderunitRate = (float)TotalRate;
                    ProductList.Add(GetProduct);
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public class ProductUnit
        {
            public string UnitPrice { get; set; }
            public string Unitqty { get; set; }
            public string Units { get; set; }
            public float orderunitRate { get; set; }
            public string Desciption { get; set; }

        }

        private void getBranchValuesamount(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);

                    string BranchID = context.Request["bid"];
                    //cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.IndentNo, indents_subtable.Qty, indents_subtable.unitQty, indents_subtable.UnitCost, indents_subtable.Cost AS unitprice, productsdata.sno,Sum(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS Total, productsdata.Qty AS RawQty, productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno  WHERE (indents.IndentNo = (SELECT MAX(IndentNo) AS IndentNo FROM indents  WHERE (Branch_id = @bsno) AND (UserData_sno = @UserName) and (indents_1.PaymentStatus<>'V'))");
                    //cmd = new MySqlCommand("SELECT productsdata.ProductName, indents_subtable.IndentNo, indents_subtable.Qty, indents_subtable.unitQty, indents_subtable.UnitCost, indents_subtable.Cost AS unitprice, productsdata.sno, SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS Total, productsdata.Qty AS RawQty, productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno  WHERE (indents.IndentNo =(SELECT MAX(IndentNo) AS IndentNo FROM indents indents_1 WHERE (Branch_id = @bsno) AND (UserData_sno = @UserName) AND (PaymentStatus <> 'V'))) AND (indents_subtable.Status = 'Delivered')");
                    cmd = new MySqlCommand("SELECT SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS Total,indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (indents.Branch_id = @Branch_id) AND (indents.I_Date between @d1 and @d2 ) ");
                    cmd.Parameters.Add("@Branch_id", BranchID);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate).AddDays(-1));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate).AddDays(-1));
                    DataTable dtYesdayIndent = vdm.SelectQuery(cmd).Tables[0];
                    double Total = 0;
                    string IndentNo = "0";
                    if (dtYesdayIndent.Rows.Count > 0)
                    {
                        if (dtYesdayIndent.Rows[0]["Total"].ToString() != "")
                        {
                            double Dtotal = (double)dtYesdayIndent.Rows[0]["Total"];
                            Total = (double)Math.Round(Dtotal, 2);
                            IndentNo = dtYesdayIndent.Rows[0]["IndentNo"].ToString();
                        }
                    }
                    //cmd = new MySqlCommand("select sum(TotalPrice) as TotalPrice from indents where userdata_sno=@UserName and Branch_id='" + BranchID + "'");
                    cmd = new MySqlCommand("SELECT branchaccounts.Amount, branchdata.CollectionType FROM  branchaccounts INNER JOIN branchdata ON branchaccounts.BranchId = branchdata.sno WHERE (branchaccounts.BranchId = @BranchID)");
                    cmd.Parameters.Add("@BranchID", BranchID);
                    DataTable dtTotalAmount = vdm.SelectQuery(cmd).Tables[0];
                    List<AmontClass> msgAmountlist = new List<AmontClass>();
                    if (dtTotalAmount.Rows.Count > 0)
                    {
                        AmontClass getAmount = new AmontClass();
                        getAmount.IndentNo = IndentNo;
                        getAmount.TodayAmount = Total;
                        getAmount.CollectionType = dtTotalAmount.Rows[0]["CollectionType"].ToString();
                        getAmount.TotalAmount = dtTotalAmount.Rows[0]["Amount"].ToString();
                        msgAmountlist.Add(getAmount);
                        string response = GetJson(msgAmountlist);
                        context.Response.Write(response);
                    }
                    else
                    {
                        AmontClass getAmount = new AmontClass();
                        getAmount.TodayAmount = Total;
                        getAmount.TotalAmount = "0";
                        getAmount.CollectionType = "Cash";
                        msgAmountlist.Add(getAmount);
                        string response = GetJson(msgAmountlist);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        public class AmontClass
        {
            public string IndentNo { get; set; }
            public double TodayAmount { get; set; }
            public string TotalAmount { get; set; }
            public string CollectionType { get; set; }
        }
        private void btnRemarksSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    var js = new JavaScriptSerializer();
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string Remarks = obj.Remarks;
                    string Denominations = obj.Denominations;
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    cmd = new MySqlCommand("Update tripdata set Remarks=@Remarks,Status=@Status,Denominations=@Denominations,CollectedAmount=@CollectedAmount,SubmittedAmount=@SubmittedAmount,Cdate=@Cdate where sno=@sno");
                    cmd.Parameters.Add("@Remarks", Remarks);
                    cmd.Parameters.Add("@Status", "P");
                    double colAmount = 0;
                    double.TryParse(obj.ColAmount, out colAmount);
                    colAmount = Math.Round(colAmount, 2);
                    cmd.Parameters.Add("@CollectedAmount", colAmount);
                    double SubAmount = 0;
                    double.TryParse(obj.SubAmount, out SubAmount);
                    SubAmount = Math.Round(SubAmount, 2);
                    cmd.Parameters.Add("@SubmittedAmount", SubAmount);
                    cmd.Parameters.Add("@Cdate", ServerDateCurrentdate);
                    cmd.Parameters.Add("@Denominations", Denominations);
                    cmd.Parameters.Add("@sno", context.Session["TripdataSno"].ToString());
                    vdm.Update(cmd);
                    cmd = new MySqlCommand("Update empaccounts set Amount=Amount-@Amount where EmpID=@EmpID");
                    cmd.Parameters.Add("@Amount", SubAmount);
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    vdm.Update(cmd);
                    string msg = "Reporting Submitted";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void CollectionSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                string Username = context.Session["userdata_sno"].ToString();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                string b_bid = context.Request["BranchID"];
                string PaidAmount = context.Request["PaidAmount"];
                string PaymentType = context.Request["PaymentType"];
                string DenominationString = context.Request["DenominationString"];
                double TotPaidAmount = 0;
                double.TryParse(PaidAmount, out TotPaidAmount);
                TotPaidAmount = Math.Round(TotPaidAmount, 2);
                if (PaymentType == "Cash")
                {
                    cmd = new MySqlCommand("insert into collections (Branchid,AmountPaid,Denominations,PaidDate,UserData_sno,PaymentType,tripId,PayTime)values(@Branchid,@AmountPaid,@Denominations,@PaidDate,@UserData_sno,@PaymentType,@tripId,@PayTime)");
                }
                else
                {
                    cmd = new MySqlCommand("insert into collections (Branchid,AmountPaid,Denominations,PaidDate,UserData_sno,PaymentType,tripId,CheckStatus,PayTime)values(@Branchid,@AmountPaid,@Denominations,@PaidDate,@UserData_sno,@PaymentType,@tripId,@CheckStatus,@PayTime)");
                    cmd.Parameters.Add("@CheckStatus", 'P');
                }
                cmd.Parameters.Add("@Branchid", b_bid);
                cmd.Parameters.Add("@AmountPaid", TotPaidAmount);
                cmd.Parameters.Add("@Denominations", DenominationString);
                cmd.Parameters.Add("@PaidDate", ServerDateCurrentdate);
                cmd.Parameters.Add("@PayTime", ServerDateCurrentdate);
                cmd.Parameters.Add("@UserData_sno", Username);
                cmd.Parameters.Add("@PaymentType", PaymentType);
                cmd.Parameters.Add("@tripId", context.Session["TripdataSno"].ToString());
                vdm.insert(cmd);
                cmd = new MySqlCommand("Update empaccounts set Amount=Amount+@Amount where EmpID=@EmpID");
                cmd.Parameters.Add("@Amount", TotPaidAmount);
                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                if (vdm.Update(cmd) == 0)
                {
                    cmd = new MySqlCommand("Insert into empaccounts(Amount,EmpID) values(@Amount,@EmpID)");
                    cmd.Parameters.Add("@Amount", TotPaidAmount);
                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                    vdm.insert(cmd);
                }
                cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                cmd.Parameters.Add("@Amount", TotPaidAmount);
                cmd.Parameters.Add("@BranchId", b_bid);
                vdm.Update(cmd);
                cmd = new MySqlCommand("SELECT sno, BranchName, phonenumber FROM branchdata WHERE (sno = @BranchID)");
                cmd.Parameters.Add("@BranchID", b_bid);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                if (dtBranch.Rows.Count > 0)
                {
                    string BranchName = dtBranch.Rows[0]["BranchName"].ToString();
                    string phonenumber = dtBranch.Rows[0]["phonenumber"].ToString();
                    string Agentid = dtBranch.Rows[0]["sno"].ToString();
                    if (phonenumber.Length == 10)
                    {
                        string Date = DateTime.Now.ToString("dd/MM/yyyy");
                        string BranchSno = context.Session["CsoNo"].ToString();
                        if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                        {
                            WebClient client = new WebClient();
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                           // string strUrl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + no + "&message=" + message1 +" &sender=VYSNVI&type=1&route=2";
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20Your%20Collection" + TotPaidAmount + "%20for%20today%20Date%20" + Date + "%20if%20any%20changes%20please%20call&sender=VYSNVI&type=1&route=2"; 
                            //string baseul = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20Your%20Collection" + TotPaidAmount + "%20for%20today%20Date%20" + Date + "%20if%20any%20changes%20please%20call&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }
                        else
                        {
                            WebClient client = new WebClient();
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20Your%20Collection" + TotPaidAmount + "%20for%20today%20Date%20" + Date + "%20if%20any%20changes%20please%20call&sender=VYSNVI&type=1&route=2"; 
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20Your%20Collection" + TotPaidAmount + "%20for%20today%20Date%20" + Date + "%20if%20any%20changes%20please%20call&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }

                        string message = " " + phonenumber + " Dear " + BranchName + " Your Collection" + TotPaidAmount + " for today Date " + Date + " if any changes please call ";
                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", Agentid);
                        cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "OnlineCollections");
                        cmd.Parameters.Add("@branchname", BranchName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                    }
                }
                List<string> msgStringlist = new List<string>();
                string msg = "Saved Successfully";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void btnOrderSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string b_bid = obj.BranchID;
                    string IndentType = obj.IndentType;
                    if (IndentType == "")
                    {
                        IndentType = context.Session["IndentType"].ToString();
                    }
                    if (IndentType == "")
                    {
                        IndentType = "Indent1";
                    }
                    if (IndentType == null)
                    {
                        IndentType = "Indent1";
                    }
                    cmd = new MySqlCommand("select BranchName,phonenumber,sno from BranchData where Sno=@sno");
                    cmd.Parameters.Add("@sno", b_bid);
                    DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                    string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                    string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                    
                    int BranchID = 0;
                    int.TryParse(b_bid, out BranchID);
                    float Qty = 0;
                    float.TryParse(obj.totqty, out Qty);
                    float Price = 0;
                    float.TryParse(obj.totTotal, out Price);
                    float TotalPrice = 0;
                    float.TryParse(obj.TotalPrice, out TotalPrice);

                    DataTable dtorders = new DataTable();
                    if (context.Session["Orders"] == null)
                    {
                        cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2)");
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@UserName", Username);
                        cmd.Parameters.Add("@IndentType", IndentType);
                        cmd.Parameters.Add("@bsno", b_bid);
                        dtorders = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["Orders"] = dtorders;
                    }
                    else
                    {
                        dtorders = (DataTable)context.Session["Orders"];
                    }
                    DataRow[] drOrders;
                    string hdnIndentNo = obj.IndentNo;

                    cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType = @IndentType)");
                    cmd.Parameters.Add("@Branch_id", BranchID);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                    DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];

                    cmd = new MySqlCommand("SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @Branch_id) AND (IndentType = @IndentType) AND (indent_date BETWEEN @d1 AND @d2)");
                    cmd.Parameters.Add("@Branch_id", BranchID);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                    DataTable dt_offerIndent = vdm.SelectQuery(cmd).Tables[0];

                    string ProductName = "";
                    string OfferProductName = "OFFER PRODUCTS\r\n";
                    double TotalQty = 0;
                    double OfferTotalQty = 0;
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Unitsqty != "0")
                        {
                            float UnitQty = 0;
                            float.TryParse(o.Unitsqty, out UnitQty);
                            ProductName += o.Product + "=" + Math.Round(UnitQty, 2) + ";\r\n";
                            TotalQty += Math.Round(UnitQty, 2);
                        }
                    }
                    foreach (orderdetail o in obj.offerdata)
                    {
                        if (o.Unitsqty != "0")
                        {
                            float UnitQty = 0;
                            float.TryParse(o.Unitsqty, out UnitQty);
                            OfferProductName += o.Product + "=" + Math.Round(UnitQty, 2) + ";\r\n";
                            OfferTotalQty += Math.Round(UnitQty, 2);
                        }
                    }
                    if (dtIndent.Rows.Count > 0)
                    {
                        string BranchIndentNo = dtIndent.Rows[0]["IndentNo"].ToString();

                        if (BranchIndentNo != "")
                        {
                            cmd = new MySqlCommand("Update indents set I_date=@I_date, UserData_sno=@UserData_sno, Status=@Status,I_modifiedby=@I_modifiedby where Branch_id=@Branch_id and IndentNo=@IndentNo");
                            cmd.Parameters.Add("@Branch_id", BranchID);
                            cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@UserData_sno", Username);
                            cmd.Parameters.Add("@Status", "O");
                            cmd.Parameters.Add("@I_modifiedby", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                            vdm.Update(cmd);
                            foreach (orderdetail o in obj.data)
                            {
                                cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,OTripId=@OTripId,UnitCost=@UnitCost,Status=@Status where IndentNo=@IndentNo and Product_sno=@Product_sno");
                                cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                double UnitCost = 0;
                                double.TryParse(o.UnitCost, out UnitCost);
                                UnitCost = Math.Round(UnitCost, 2);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                    cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    cmd.Parameters.Add("@UnitCost", UnitCost);
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    cmd.Parameters.Add("@Status", "Ordered");
                                    cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                                foreach (DataRow dr in dtorders.Rows)
                                {
                                    string Prodsno = dr["sno"].ToString();
                                    string Psno = o.Productsno;
                                    if (Prodsno == Psno)
                                    {
                                        cmd = new MySqlCommand("Update  EditedIndents set Prodsno=@Prodsno,EntryTime=@EntryTime,ActualQty=@ActualQty,EditQty=@EditQty where BranchID=@BranchID and IndentNo=@IndentNo");
                                        cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                        cmd.Parameters.Add("@Prodsno", o.Productsno);
                                        cmd.Parameters.Add("@BranchID", b_bid);
                                        cmd.Parameters.Add("@EntryTime", ServerDateCurrentdate);
                                        double Aqty = 0;
                                        double.TryParse(dr["unitQty"].ToString(), out Aqty);
                                        Aqty = Math.Round(Aqty, 2);
                                        cmd.Parameters.Add("@ActualQty", Aqty);
                                        double Eqty = 0;
                                        double.TryParse(o.ReturnQty, out Eqty);
                                        Eqty = Math.Round(Eqty, 2);
                                        cmd.Parameters.Add("@EditQty", Eqty);
                                        if (vdm.Update(cmd) == 0)
                                        {
                                            cmd = new MySqlCommand("insert into EditedIndents (IndentNo,Prodsno,BranchID,EntryTime,ActualQty,EditQty)values(@IndentNo,@Prodsno,@BranchID,@EntryTime,@ActualQty,@EditQty)");
                                            cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                            cmd.Parameters.Add("@Prodsno", o.Productsno);
                                            cmd.Parameters.Add("@BranchID", b_bid);
                                            cmd.Parameters.Add("@EntryTime", ServerDateCurrentdate);
                                            cmd.Parameters.Add("@ActualQty", Aqty);
                                            cmd.Parameters.Add("@EditQty", Eqty);
                                            vdm.insert(cmd);
                                        }
                                    }
                                }
                            }
                            if (dt_offerIndent.Rows.Count > 0)
                            {
                                string offerIndentNo = dt_offerIndent.Rows[0]["idoffer_indents"].ToString();
                                if (offerIndentNo != "")
                                {
                                    cmd = new MySqlCommand("UPDATE offer_indents SET indent_date = @indent_date, indents_id = @indents_id, I_modified_by = @I_modified_by WHERE (idoffer_indents = @idoffer_indents) AND (agent_id=@Branch_id)");
                                    cmd.Parameters.Add("@indent_date", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@Branch_id", BranchID);

                                    cmd.Parameters.Add("@indents_id", BranchIndentNo);
                                    cmd.Parameters.Add("@I_modified_by", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@idoffer_indents", offerIndentNo);
                                    vdm.Update(cmd);
                                    foreach (orderdetail o in obj.offerdata)
                                    {
                                        if (o.Productsno != null)
                                        {
                                            double unitQty = 0;
                                            double.TryParse(o.Unitsqty, out unitQty);
                                            unitQty = Math.Round(unitQty, 2);
                                            cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                            cmd.Parameters.Add("@offer_indent_qty", unitQty);
                                            cmd.Parameters.Add("@idoffer_indents", offerIndentNo);
                                            cmd.Parameters.Add("@product_id", o.Productsno);
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                double UnitCost = 0;
                                                double.TryParse(o.UnitCost, out UnitCost);
                                                UnitCost = Math.Round(UnitCost, 2);

                                                cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                                cmd.Parameters.Add("idoffer_indents", offerIndentNo);
                                                cmd.Parameters.Add("product_id", o.Productsno);
                                                //cmd.Parameters.Add("unit_price", UnitCost);
                                                cmd.Parameters.Add("unit_price", UnitCost);
                                                cmd.Parameters.Add("offer_indent_qty", unitQty);
                                                cmd.Parameters.Add("offer_delivered_qty", "0");
                                                if (unitQty != 0.0)
                                                {
                                                    vdm.insert(cmd);
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.offer_from = @d1) AND (offers_assignment.salesoffice_id = @soid) OR (offers_assignment.status = 1) AND (offers_assignment.offer_to >= @d1) AND (offers_assignment.salesoffice_id = @soid)");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                                cmd.Parameters.Add("@soid", context.Session["CsoNo"].ToString());
                                DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                                DataView view = new DataView(dtoffers);
                                DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");
                                string idoffers_assignment = "0";
                                long offer_indent_no = 0;
                                if (dtoffers.Rows.Count > 0)
                                {

                                    idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                                    cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                                    cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                                    cmd.Parameters.Add("@salesoffice_id", context.Session["CsoNo"].ToString());
                                    cmd.Parameters.Add("@agent_id", BranchID);
                                    cmd.Parameters.Add("@indent_date", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@IndentType", IndentType);

                                    cmd.Parameters.Add("@indents_id", BranchIndentNo);
                                    long offerindentno = vdm.insertScalar(cmd);
                                    offer_indent_no = offerindentno;

                                    #region offer_indent
                                    foreach (orderdetail o in obj.offerdata)
                                    {
                                        if (o.Productsno != null)
                                        {
                                            double unitQty = 0;
                                            double.TryParse(o.Unitsqty, out unitQty);
                                            unitQty = Math.Round(unitQty, 2);
                                            //cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = offer_indent_qty + @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                            //cmd.Parameters.Add("@offer_indent_qty", unitQty);
                                            //cmd.Parameters.Add("@idoffer_indents", offer_indent_no);
                                            //cmd.Parameters.Add("@product_id", o.Productsno);
                                            //if (vdm.Update(cmd) == 0)
                                            //{
                                            double UnitCost = 0;
                                            double.TryParse(o.UnitCost, out UnitCost);
                                            UnitCost = Math.Round(UnitCost, 2);

                                            cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                            cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                            cmd.Parameters.Add("product_id", o.Productsno);
                                            //cmd.Parameters.Add("unit_price", UnitCost);
                                            cmd.Parameters.Add("unit_price", UnitCost);
                                            cmd.Parameters.Add("offer_indent_qty", unitQty);
                                            cmd.Parameters.Add("offer_delivered_qty", "0");
                                            if (unitQty != 0.0)
                                            {
                                                vdm.insert(cmd);
                                            }
                                            //}
                                        }
                                    }

                                    #endregion

                                }

                            }
                            cmd = new MySqlCommand("Update Indents set PaymentStatus=@PamentStatus where IndentNo=@IndentNo");
                            cmd.Parameters.Add("@PamentStatus", 'A');
                            cmd.Parameters.Add("@IndentNo", hdnIndentNo);
                            vdm.Update(cmd);

                            
                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into indents (Branch_id,TotalQty,TotalPrice,I_date,UserData_sno,Status,PaymentStatus,I_createdby,IndentType)values(@Branch_id,@TotalQty,@TotalPrice,@I_date,@UserData_sno,@Status,@PaymentStatus,@I_createdby,@IndentType)");
                            cmd.Parameters.Add("@Branch_id", BranchID);
                            cmd.Parameters.Add("@TotalQty", Qty);
                            cmd.Parameters.Add("@TotalPrice", Price);
                            cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@UserData_sno", Username);
                            cmd.Parameters.Add("@Status", "O");
                            cmd.Parameters.Add("@PaymentStatus", 'A');
                            cmd.Parameters.Add("@IndentType", IndentType);
                            long IndentNo = vdm.insertScalar(cmd);

                            //cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from,offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.offer_from >= @d1) OR (offers_assignment.status = 1) AND (offers_assignment.offer_to <= @d1)");
                            //cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                            //DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];

                            cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id=@bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                            cmd.Parameters.Add("@bsno", context.Session["CsoNo"].ToString());
                            DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                            DataView view = new DataView(dtoffers);
                            DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");
                            DataTable distincttable1 = view.ToTable(true, "id_offers", "product_id", "offer_product_id", "qty_if_above", "offer_qty");
                            //DataTable distincttable2 = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");
                            string idoffers_assignment = "0";
                            long offer_indent_no = 0;
                            if (dtoffers.Rows.Count > 0)
                            {
                                
                                idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                                cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                                cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                                cmd.Parameters.Add("@salesoffice_id", context.Session["CsoNo"].ToString());
                                cmd.Parameters.Add("@agent_id", BranchID);
                                cmd.Parameters.Add("@indent_date", ServerDateCurrentdate);
                                cmd.Parameters.Add("@indents_id", IndentNo);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                long offerindentno = vdm.insertScalar(cmd);
                                offer_indent_no = offerindentno;
                            }


                            
                            
                            foreach (orderdetail o in obj.data)
                            {
                                if (o.Productsno != null)
                                {
                                    cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                    cmd.Parameters.Add("@IndentNo", IndentNo);
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    double UnitCost = 0;
                                    double.TryParse(o.UnitCost, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);
                                    cmd.Parameters.Add("@UnitCost", UnitCost);
                                    double unitQty = 0;
                                    double.TryParse(o.Unitsqty, out unitQty);
                                    unitQty = Math.Round(unitQty, 2);
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    cmd.Parameters.Add("@Status", "Ordered");
                                    cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                   
                                   
                                }
                            }
                            #region offer_indent
                            foreach (orderdetail o in obj.offerdata)
                            {
                                if (o.Productsno != null)
                                {
                                    double unitQty = 0;
                                    double.TryParse(o.Unitsqty, out unitQty);
                                    unitQty = Math.Round(unitQty, 2);
                                    //cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = offer_indent_qty + @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                    //cmd.Parameters.Add("@offer_indent_qty", unitQty);
                                    //cmd.Parameters.Add("@idoffer_indents", offer_indent_no);
                                    //cmd.Parameters.Add("@product_id", o.Productsno);
                                    //if (vdm.Update(cmd) == 0)
                                    //{
                                        double UnitCost = 0;
                                        double.TryParse(o.UnitCost, out UnitCost);
                                        UnitCost = Math.Round(UnitCost, 2);

                                        cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                        cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                        cmd.Parameters.Add("product_id", o.Productsno);
                                        //cmd.Parameters.Add("unit_price", UnitCost);
                                        cmd.Parameters.Add("unit_price", UnitCost);
                                        cmd.Parameters.Add("offer_indent_qty", unitQty);
                                        cmd.Parameters.Add("offer_delivered_qty", "0");
                                        if (unitQty != 0.0)
                                        {
                                            vdm.insert(cmd);
                                        }
                                    //}
                                }
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("insert into indents (Branch_id,TotalQty,TotalPrice,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@TotalQty,@TotalPrice,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                        cmd.Parameters.Add("@Branch_id", BranchID);
                        cmd.Parameters.Add("@TotalQty", Qty);
                        cmd.Parameters.Add("@TotalPrice", Price);
                        cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                        cmd.Parameters.Add("@UserData_sno", Username);
                        cmd.Parameters.Add("@Status", "O");
                        cmd.Parameters.Add("@IndentType", IndentType);
                        cmd.Parameters.Add("@PaymentStatus", 'A');
                        long IndentNo = vdm.insertScalar(cmd);

                        cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.offer_from = @d1) AND (offers_assignment.salesoffice_id = @soid) OR (offers_assignment.status = 1) AND (offers_assignment.offer_to >= @d1) AND (offers_assignment.salesoffice_id = @soid)");
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@soid", context.Session["CsoNo"].ToString());
                        DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];
                        DataView view = new DataView(dtoffers);
                        DataTable distincttable = view.ToTable(true, "idoffers_assignment", "offers_assignment_name");
                        DataTable distincttable1 = view.ToTable(true, "id_offers", "product_id", "offer_product_id", "qty_if_above", "offer_qty");
                        //DataTable distincttable2 = view.ToTable(true, "product_id", "offer_product_id");
                        string idoffers_assignment = "0";
                        long offer_indent_no = 0;
                        if (dtoffers.Rows.Count > 0)
                        {

                            idoffers_assignment = distincttable.Rows[0]["idoffers_assignment"].ToString();

                            cmd = new MySqlCommand("INSERT INTO offer_indents (idoffers_assignment, salesoffice_id, agent_id, indent_date, indents_id,IndentType) VALUES (@idoffers_assignment, @salesoffice_id, @agent_id, @indent_date, @indents_id,@IndentType)");
                            cmd.Parameters.Add("@idoffers_assignment", idoffers_assignment);
                            cmd.Parameters.Add("@salesoffice_id", context.Session["CsoNo"].ToString());
                            cmd.Parameters.Add("@agent_id", BranchID);
                            cmd.Parameters.Add("@indent_date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@IndentType", IndentType);

                            cmd.Parameters.Add("@indents_id", IndentNo);
                            long offerindentno = vdm.insertScalar(cmd);
                            offer_indent_no = offerindentno;

                        }

                        

                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                cmd.Parameters.Add("@IndentNo", IndentNo);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                double UnitCost = 0;
                                double.TryParse(o.UnitCost, out UnitCost);
                                UnitCost = Math.Round(UnitCost, 2);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                if (unitQty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }

                        #region offer_indent
                        foreach (orderdetail o in obj.offerdata)
                        {
                            if (o.Productsno != null)
                            {
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                //cmd = new MySqlCommand("UPDATE offer_indents_sub SET offer_indent_qty = offer_indent_qty + @offer_indent_qty WHERE (idoffer_indents = @idoffer_indents) AND (product_id = @product_id)");
                                //cmd.Parameters.Add("@offer_indent_qty", unitQty);
                                //cmd.Parameters.Add("@idoffer_indents", offer_indent_no);
                                //cmd.Parameters.Add("@product_id", o.Productsno);
                                //if (vdm.Update(cmd) == 0)
                                //{
                                    double UnitCost = 0;
                                    double.TryParse(o.UnitCost, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);

                                    cmd = new MySqlCommand("INSERT INTO offer_indents_sub (idoffer_indents, product_id, unit_price, offer_indent_qty, offer_delivered_qty) VALUES (@idoffer_indents, @product_id, @unit_price, @offer_indent_qty, @offer_delivered_qty)");
                                    cmd.Parameters.Add("idoffer_indents", offer_indent_no);
                                    cmd.Parameters.Add("product_id", o.Productsno);
                                    //cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("unit_price", UnitCost);
                                    cmd.Parameters.Add("offer_indent_qty", unitQty);
                                    cmd.Parameters.Add("offer_delivered_qty", "0");
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                //}
                            }
                        }

                        #endregion
                    }
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            cmd = new MySqlCommand("Update branchproducts set flag=@flag  where branch_sno=@branch_sno and product_sno=@product_sno");
                            float UnitCost = 0;
                            cmd.Parameters.Add("@flag", true);
                            cmd.Parameters.Add("@branch_sno", BranchID);
                            cmd.Parameters.Add("@product_sno", o.Productsno);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert Into branchproducts(branch_sno,product_sno,flag,userdata_sno,Unitprice) values(@branch_sno,@product_sno,@flag,@userdata_sno,@Unitprice)");
                                cmd.Parameters.Add("@branch_sno", BranchID);
                                cmd.Parameters.Add("@product_sno", o.Productsno);
                                cmd.Parameters.Add("@flag", false);
                                cmd.Parameters.Add("@userdata_sno", Username);
                                cmd.Parameters.Add("@Unitprice", UnitCost);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    if (phonenumber.Length == 10)
                    {
                        string Date = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                        WebClient client = new WebClient();
                        string companyname = "\r\nPowered By Vyshnavi";
                        string BranchSno = context.Session["CsoNo"].ToString();
                        if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                        {
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20Your%20indent%20for%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20Your%20indent%20for%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }
                        else
                        {

                            string baseurl = "http://smsatm.net/v3/api.php?username=vaishnavi&apikey=273fee3af464032f2211&senderid=Vysnvi&templateid=1507164603279547820&mobile=" + phonenumber + "&message=" + BranchName + ",%20Indent%20For%20Date:" + Date + "%20Completed" + ProductName + ";%20TotalQty" + TotalQty + "Sri%20vyshnavi%20foods%20pvt%20ltd";
                            //string baseurl = "http://smsatm.net/v3/api.php?username=vaishnavi&apikey=273fee3af464032f2211&senderid=Vysnvi&templateid=1507164603279547820&mobile=7013732814&message=Dear%20" + BranchName + "%20Your%20indent%20for%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + ""; 
                            //string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20Your%20indent%20for%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 

                           // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20Your%20indent%20for%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }

                        string message = " Dear " + BranchName + " Your indent for Date " + Date + " , " + ProductName + "Total Ltrs =" + TotalQty + " ";

                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", BranchID);
                        cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "Indent");
                        cmd.Parameters.Add("@branchname", BranchName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Saved";
                    MsgList.Add(msg);
                    string responses = GetJson(MsgList);
                    context.Response.Write(responses);
                }
            }
            catch (Exception ex)
            {
                List<string> MsgList = new List<string>();
                if (ex.Message == "Unable to connect to the remote server")
                {
                    string msg = "Data Saved but Message Not Sent";
                    MsgList.Add(msg);
                }
                else
                {
                    string msg = ex.ToString();
                    MsgList.Add(msg);
                }

                string response = GetJson(MsgList);
                context.Response.Write(response);
            }
        }
        private void btnDeliversSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);

                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string b_bid = obj.BranchID;
                    cmd = new MySqlCommand("select BranchName,phonenumber from BranchData where Sno=@sno");
                    cmd.Parameters.Add("@sno", b_bid);
                    DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                    string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                    string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                    int BranchID = 0;
                    int.TryParse(b_bid, out BranchID);
                    string indent = obj.IndentNo;
                    float Price = 0;
                    float.TryParse(obj.totTotal, out Price);
                    float TotalCost = 0;
                    float.TryParse(obj.TotalCost, out TotalCost);
                    float Returnqty;
                    long IndentsNo = 0;
                    DataTable dtDelivers = new DataTable();
                    if (context.Session["Delivers"] == null)
                    {
                        cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) group By productsdata.ProductName ");
                        cmd.Parameters.Add("@UserName", Username);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate.AddDays(-1)));
                        cmd.Parameters.Add("@bsno", b_bid);
                        dtDelivers = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["Delivers"] = dtDelivers;
                    }
                    else
                    {
                        dtDelivers = (DataTable)context.Session["Delivers"];
                    }
                    int DataCount = obj.data.Count;
                    string ProductName = "";
                    double TotalQty = 0;
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.ReturnQty != "0")
                        {
                            float ReturnQty = 0;
                            float.TryParse(o.ReturnQty, out ReturnQty);
                            ProductName += o.Product + "=" + Math.Round(ReturnQty, 2) + ";";
                            TotalQty += Math.Round(ReturnQty, 2);
                        }
                    }
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            string ind = "0";
                            ind = o.hdnSno;
                            if (o.hdnSno == "")
                            {
                                ind = "0";
                            }
                            if (ind != "0")
                            {
                                cmd = new MySqlCommand("UPDATE  indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty,D_date=@D_date,DTripId=@DTripId,Status=@Status,UnitCost=@UnitCost,DelTime=@DelTime where Product_sno=@Product_sno and IndentNo=@IndentNo");
                                int IndentNo = 0;
                                int.TryParse(o.IndentNo, out IndentNo);
                                cmd.Parameters.Add("@IndentNo", IndentNo);
                                int Productsno = 0;
                                int.TryParse(o.Productsno, out Productsno);
                                cmd.Parameters.Add("@Product_sno", Productsno);
                                float UnitCost = 0;
                                float.TryParse(o.orderunitRate, out UnitCost);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                float.TryParse(o.ReturnQty, out Returnqty);
                                cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                float Leak = 0;
                                float.TryParse(o.LeakQty, out Leak);
                                cmd.Parameters.Add("@LeakQty", Leak);
                                cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@Status", o.Status);
                                if (o.Status == "Pending")
                                {
                                    cmd = new MySqlCommand("Insert into pendingtransactions(Sno,Date,Delivered) values(@Sno,@Date,@Delivered)");
                                    cmd.Parameters.Add("@Sno", o.hdnSno);
                                    cmd.Parameters.Add("@Date", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@Delivered", Returnqty);
                                    vdm.insert(cmd);
                                }
                                cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                                cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                                vdm.Update(cmd);

                                foreach (DataRow dr in dtDelivers.Rows)
                                {
                                    string Status = dr["Status"].ToString();

                                    if (Status == "Delivered")
                                    {
                                        string Prodsno = dr["Product_sno"].ToString();
                                        string Psno = o.Productsno;

                                        if (Prodsno == Psno)
                                        {
                                            float Aqty = 0;
                                            float.TryParse(dr["DeliveryQty"].ToString(), out Aqty);
                                            float Eqty = 0;
                                            float.TryParse(o.ReturnQty, out Eqty);
                                            float Lqty = 0;
                                            float.TryParse(o.LeakQty, out Lqty);
                                            float TQty = Aqty - Eqty;
                                            if (TQty >= 1)
                                            {
                                                float TotIndentcost = TQty * UnitCost;
                                                cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                                                cmd.Parameters.Add("@Amount", TotIndentcost);
                                                cmd.Parameters.Add("@BranchId", b_bid);
                                                if (vdm.Update(cmd) == 0)
                                                {
                                                    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                    cmd.Parameters.Add("@Amount", TotIndentcost);
                                                    cmd.Parameters.Add("@BranchId", b_bid);
                                                    vdm.insert(cmd);
                                                }
                                            }
                                            else
                                            {

                                                TQty = Math.Abs(TQty);
                                                float TotIndentcost = TQty * UnitCost;
                                                cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                                cmd.Parameters.Add("@Amount", TotIndentcost);
                                                cmd.Parameters.Add("@BranchId", b_bid);
                                                if (vdm.Update(cmd) == 0)
                                                {
                                                    cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                    cmd.Parameters.Add("@Amount", TotIndentcost);
                                                    cmd.Parameters.Add("@BranchId", b_bid);
                                                    vdm.insert(cmd);
                                                }
                                            }
                                        }
                                    }
                                    if (Status == "Ordered")
                                    {
                                        string Prodsno = dr["Product_sno"].ToString();
                                        string Psno = o.Productsno;
                                        if (Prodsno == Psno)
                                        {
                                            cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                            float TotRate = 0;
                                            TotRate = UnitCost * Returnqty;
                                            cmd.Parameters.Add("@Amount", TotRate);
                                            cmd.Parameters.Add("@BranchId", b_bid);
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                cmd.Parameters.Add("@Amount", TotRate);
                                                cmd.Parameters.Add("@BranchId", b_bid);
                                                vdm.insert(cmd);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (o.Productsno != null)
                                {
                                    if (indent == "")
                                    {
                                        indent = "0";
                                    }
                                    if (indent == "0")
                                    {
                                        if (IndentsNo == 0)
                                        {
                                            cmd = new MySqlCommand("insert into indents (Branch_id,I_date,UserData_sno,Status,PaymentStatus)values(@Branch_id,@I_date,@UserData_sno,@Status,@PaymentStatus)");
                                            cmd.Parameters.Add("@Branch_id", BranchID);
                                            cmd.Parameters.Add("@I_date", ServerDateCurrentdate.AddDays(-1));
                                            cmd.Parameters.Add("@UserData_sno", Username);
                                            cmd.Parameters.Add("@Status", "O");
                                            cmd.Parameters.Add("@PaymentStatus", 'A');
                                            IndentsNo = vdm.insertScalar(cmd);
                                        }
                                    }
                                    cmd = new MySqlCommand("Update indents_subtable set DeliveryQty=@DeliveryQty,Status=@Status,D_date=@D_date,LeakQty=@LeakQty , DTripId=@DTripId,DelTime=@DelTime where  IndentNo=@IndentNo and  Product_sno=@Product_sno ");
                                    float.TryParse(o.ReturnQty, out Returnqty);
                                    cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                    if (indent == "0")
                                    {
                                        cmd.Parameters.Add("@IndentNo", IndentsNo);
                                    }
                                    else
                                    {
                                        int DIndent = 0;
                                        int.TryParse(o.IndentNo, out DIndent);
                                        cmd.Parameters.Add("@IndentNo", DIndent);
                                    }
                                    float Leak = 0;
                                    float.TryParse(o.LeakQty, out Leak);
                                    cmd.Parameters.Add("@LeakQty", Leak);
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    cmd.Parameters.Add("@Status", "Delivered");
                                    cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                                    float unitQty = 0;
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    float UnitCost = 0;
                                    float.TryParse(o.orderunitRate, out UnitCost);
                                    cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                    cmd.Parameters.Add("@UnitCost", UnitCost);
                                    if (vdm.Update(cmd) == 0)
                                    {
                                        cmd = new MySqlCommand("insert into indents_subtable (DeliveryQty,D_date,IndentNo,Product_sno,Status,unitQty,UnitCost,LeakQty,DTripId,DelTime)values(@DeliveryQty,@D_date,@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@LeakQty,@DTripId,@DelTime)");
                                        float.TryParse(o.ReturnQty, out Returnqty);
                                        cmd.Parameters.Add("@DeliveryQty", Returnqty);
                                        cmd.Parameters.Add("@DelTime", ServerDateCurrentdate);
                                        cmd.Parameters.Add("@D_date", ServerDateCurrentdate);
                                        if (indent == "0")
                                        {
                                            cmd.Parameters.Add("@IndentNo", IndentsNo);
                                        }
                                        else
                                        {
                                            int DIndent = 0;
                                            int.TryParse(o.IndentNo, out DIndent);
                                            cmd.Parameters.Add("@IndentNo", DIndent);
                                        }
                                        cmd.Parameters.Add("@LeakQty", Leak);
                                        cmd.Parameters.Add("@Product_sno", o.Productsno);
                                        cmd.Parameters.Add("@Status", "Delivered");
                                        cmd.Parameters.Add("@unitQty", unitQty);
                                        cmd.Parameters.Add("@DTripId", context.Session["TripdataSno"].ToString());
                                        cmd.Parameters.Add("@UnitCost", UnitCost);
                                        vdm.insert(cmd);
                                    }
                                    if (o.Status == "Delivered")
                                    {
                                        if (dtDelivers != null)
                                        {
                                            foreach (DataRow dr in dtDelivers.Rows)
                                            {
                                                string Prodsno = dr["Product_sno"].ToString();
                                                string Psno = o.Productsno;

                                                if (Prodsno == Psno)
                                                {
                                                    float Aqty = 0;
                                                    float.TryParse(dr["DeliveryQty"].ToString(), out Aqty);
                                                    float Eqty = 0;
                                                    float.TryParse(o.ReturnQty, out Eqty);
                                                    float Lqty = 0;
                                                    float.TryParse(o.LeakQty, out Lqty);
                                                    float TQty = Aqty - Eqty;
                                                    if (TQty >= 1)
                                                    {
                                                        float TotIndentcost = TQty * UnitCost;
                                                        cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                                                        cmd.Parameters.Add("@Amount", TotIndentcost);
                                                        cmd.Parameters.Add("@BranchId", b_bid);
                                                        if (vdm.Update(cmd) == 0)
                                                        {
                                                            cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                            cmd.Parameters.Add("@Amount", TotIndentcost);
                                                            cmd.Parameters.Add("@BranchId", b_bid);
                                                            vdm.insert(cmd);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        TQty = Math.Abs(TQty);
                                                        float TotIndentcost = TQty * UnitCost;
                                                        cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                                        cmd.Parameters.Add("@Amount", TotIndentcost);
                                                        cmd.Parameters.Add("@BranchId", b_bid);
                                                        if (vdm.Update(cmd) == 0)
                                                        {
                                                            cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                            cmd.Parameters.Add("@Amount", TotIndentcost);
                                                            cmd.Parameters.Add("@BranchId", b_bid);
                                                            vdm.insert(cmd);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                                            float TotRate = 0;
                                            TotRate = UnitCost * Returnqty;
                                            cmd.Parameters.Add("@Amount", TotRate);
                                            cmd.Parameters.Add("@BranchId", b_bid);
                                            if (vdm.Update(cmd) == 0)
                                            {
                                                cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                                                cmd.Parameters.Add("@Amount", TotRate);
                                                cmd.Parameters.Add("@BranchId", b_bid);
                                                vdm.insert(cmd);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (dtDelivers != null)
                        {
                            foreach (DataRow dr in dtDelivers.Rows)
                            {
                                string Prodsno = dr["Product_sno"].ToString();
                                string Psno = o.Productsno;
                                if (Prodsno == Psno)
                                {
                                    float Aqty = 0;
                                    float.TryParse(dr["unitQty"].ToString(), out Aqty);
                                    float Eqty = 0;
                                    float.TryParse(o.ReturnQty, out Eqty);
                                    float Lqty = 0;
                                    float.TryParse(o.LeakQty, out Lqty);
                                    float TQty = Eqty + Lqty;
                                    if (Aqty != Eqty)
                                    {
                                        cmd = new MySqlCommand("Update  EditedDelivery set Prodsno=@Prodsno,DEntryTime=@DEntryTime,DeliveryQty=@DeliveryQty,DEditQty=@DEditQty where BranchID=@BranchID and IndentNo=@IndentNo");
                                        int IndentNo = 0;
                                        int.TryParse(o.IndentNo, out IndentNo);
                                        cmd.Parameters.Add("@IndentNo", IndentNo);
                                        cmd.Parameters.Add("@Prodsno", o.Productsno);
                                        cmd.Parameters.Add("@BranchID", b_bid);
                                        cmd.Parameters.Add("@DEntryTime", ServerDateCurrentdate);
                                        cmd.Parameters.Add("@DeliveryQty", Aqty);
                                        cmd.Parameters.Add("@DEditQty", Eqty);
                                        if (vdm.Update(cmd) == 0)
                                        {
                                            cmd = new MySqlCommand("insert into EditedDelivery (IndentNo,Prodsno,BranchID,DEntryTime,DeliveryQty,DEditQty)values(@IndentNo,@Prodsno,@BranchID,@DEntryTime,@DeliveryQty,@DEditQty)");
                                            cmd.Parameters.Add("@IndentNo", IndentNo);
                                            cmd.Parameters.Add("@Prodsno", o.Productsno);
                                            cmd.Parameters.Add("@BranchID", b_bid);
                                            cmd.Parameters.Add("@DEntryTime", ServerDateCurrentdate);
                                            float.TryParse(dr["unitQty"].ToString(), out Aqty);
                                            cmd.Parameters.Add("@DeliveryQty", Aqty);
                                            //float.TryParse(o.ReturnQty, out Eqty);
                                            cmd.Parameters.Add("@DEditQty", Eqty);
                                            vdm.insert(cmd);
                                        }
                                    }
                                }
                            }
                        }
                        cmd = new MySqlCommand("update tripsubdata set DeliverQty=DeliverQty+@DeliverQty where ProductId=@ProductId and Tripdata_sno=@Tripdata_sno");
                        float deliverQty = 0;
                        float.TryParse(o.ReturnQty, out deliverQty);
                        cmd.Parameters.Add("@DeliverQty", deliverQty);
                        int Prsno = 0;
                        int.TryParse(o.Productsno, out Prsno);
                        cmd.Parameters.Add("@ProductId", Prsno);
                        int TripdataSno = 0;
                        int.TryParse(context.Session["TripdataSno"].ToString(), out TripdataSno);
                        cmd.Parameters.Add("@Tripdata_sno", TripdataSno);
                        vdm.Update(cmd);
                        string SalesType = context.Session["Salestype"].ToString();
                        if (SalesType == "Plant")
                        {
                            //cmd = new MySqlCommand("update branchproducts set manufact_remaining_qty=@manufact_remaining_qty where Product_sno=@Product_sno and branch_sno=@branch_sno");
                            //float ReturnQty = 0;
                            //float.TryParse(o.ReturnQty, out ReturnQty);
                            //cmd.Parameters.Add("@manufact_remaining_qty", ReturnQty);
                            //cmd.Parameters.Add("@Product_sno", o.Productsno);
                            //cmd.Parameters.Add("@branch_sno", BranchID);
                            //if (vdm.Update(cmd) == 0)
                            //{
                            //    cmd = new MySqlCommand("Insert into branchproducts (manufact_remaining_qty,Product_sno,branch_sno) values(@manufact_remaining_qty,@Product_sno,@branch_sno)");
                            //    cmd.Parameters.Add("@manufact_remaining_qty", ReturnQty);
                            //    cmd.Parameters.Add("@Product_sno", o.Productsno);
                            //    cmd.Parameters.Add("@branch_sno", BranchID);
                            //    vdm.insert(cmd);
                            //}
                        }
                        if (SalesType == "SALES OFFICE")
                        {
                            //cmd = new MySqlCommand("update branchproducts set manufact_remaining_qty=manufact_remaining_qty-@manufact_remaining_qty where Product_sno=@Product_sno and branch_sno=@branch_sno");
                            //float ReturnQty = 0;
                            //float.TryParse(o.ReturnQty, out ReturnQty);
                            //cmd.Parameters.Add("@manufact_remaining_qty", ReturnQty);
                            //cmd.Parameters.Add("@Product_sno", o.Productsno);
                            //cmd.Parameters.Add("@branch_sno", BranchID);
                            //vdm.Update(cmd);
                        }
                    }
                    /////// .........CHANGE..........////////////
                    DataTable dtPrevInventory = new DataTable();
                    cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, inventory_monitor.Qty AS BranchQty, invtransactions12.Qty FROM invmaster INNER JOIN inventory_monitor ON invmaster.sno = inventory_monitor.Inv_Sno INNER JOIN  invtransactions12 ON invmaster.sno = invtransactions12.B_inv_sno AND inventory_monitor.BranchId = invtransactions12.FromTran WHERE (invtransactions12.ToTran = @ToTrans) and (invtransactions12.FromTran = @FromTran) AND (invtransactions12.TransType = @TransType) AND (inventory_monitor.BranchId = @BranchID) GROUP BY invmaster.InvName ORDER BY invmaster.sno");
                        cmd.Parameters.Add("@TransType", "2");
                    cmd.Parameters.Add("@BranchID", BranchID);
                    cmd.Parameters.Add("@FromTran", context.Session["TripdataSno"].ToString());
                    cmd.Parameters.Add("@ToTrans", BranchID);
                    ////cmd = new MySqlCommand("SELECT invmaster.InvName, invmaster.sno, invtransactions.Qty,invtransactions.TodayQty, inventory_monitor.Qty AS BranchQty FROM invmaster INNER JOIN invtransactions ON invmaster.sno = invtransactions.B_Inv_Sno INNER JOIN inventory_monitor ON invtransactions.BranchId = inventory_monitor.BranchId WHERE (inventory_monitor.BranchId = @BranchId) AND (invtransactions.Status =@Status)  AND (invtransactions.TripID = @TripID)GROUP BY invmaster.InvName");
                    ////cmd.Parameters.Add("@Status", 'D');
                    ////cmd.Parameters.Add("@BranchId", BranchID);
                    ////cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                    dtPrevInventory = vdm.SelectQuery(cmd).Tables[0];
                    
                    foreach (Inventorydetail o in obj.Inventorydetails)
                    {
                        if (o.SNo == null || o.SNo == "")
                        {
                        }
                        else
                        {

                            if (dtPrevInventory.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtPrevInventory.Rows)
                                {
                                    string InvSno = o.InvSno;
                                    string PInvSno = dr["sno"].ToString();
                                    if (InvSno == PInvSno)
                                    {
                                        int GivenQty = 0;
                                        int.TryParse(o.GivenQty, out GivenQty);
                                        int TodayQty = 0;
                                        int.TryParse(dr["Qty"].ToString(), out TodayQty);
                                        int TotQty = GivenQty - TodayQty;
                                        if (TotQty >= 1)
                                        {
                                            cmd = new MySqlCommand("update tripinvdata set Remaining=Remaining-@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                            cmd.Parameters.Add("@Remaining", TotQty);
                                            cmd.Parameters.Add("@invId", o.InvSno);
                                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                            cmd.Parameters.Add("@Qty", TotQty);
                                            cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                            cmd.Parameters.Add("@BranchId", b_bid);
                                            vdm.Update(cmd);
                                        }
                                        else
                                        {
                                            TotQty = Math.Abs(TotQty);
                                            cmd = new MySqlCommand("update tripinvdata set Remaining=Remaining+@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                            cmd.Parameters.Add("@Remaining", TotQty);
                                            cmd.Parameters.Add("@invId", o.InvSno);
                                            cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("update inventory_monitor set Qty=Qty-@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                            cmd.Parameters.Add("@Qty", TotQty);
                                            cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                            cmd.Parameters.Add("@BranchId", b_bid);
                                            vdm.Update(cmd);
                                        }
                                    }
                                    else
                                    {
                                        //cmd = new MySqlCommand("update tripinvdata set Remaining=Remaining-@Remaining where Tripdata_sno=@TripID");
                                        //int GivenQty = 0;
                                        //int.TryParse(o.GivenQty, out GivenQty);
                                        //cmd.Parameters.Add("@Remaining", GivenQty);
                                        //cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                        //vdm.Update(cmd);
                                        //cmd = new MySqlCommand("update inventory_monitor set Qty=@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                        //cmd.Parameters.Add("@Qty", o.BalanceQty);
                                        //cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                        //cmd.Parameters.Add("@BranchId", b_bid);
                                        //vdm.Update(cmd);
                                    }
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("update tripinvdata set Remaining=Remaining-@Remaining where Tripdata_sno=@TripID and invId=@invId");
                                int GivenQty = 0;
                                int.TryParse(o.GivenQty, out GivenQty);
                                cmd.Parameters.Add("@Remaining", GivenQty);
                                cmd.Parameters.Add("@invId", o.InvSno);
                                cmd.Parameters.Add("@TripID", context.Session["TripdataSno"].ToString());
                                vdm.Update(cmd);
                                cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                                cmd.Parameters.Add("@Qty", GivenQty);
                                cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                cmd.Parameters.Add("@BranchId", b_bid);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                    cmd.Parameters.Add("@Qty", GivenQty);
                                    cmd.Parameters.Add("@Inv_Sno", o.InvSno);
                                    cmd.Parameters.Add("@BranchId", b_bid);
                                    vdm.insert(cmd);
                                }
                            }
                            cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                            cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                            cmd.Parameters.Add("@Qty", o.GivenQty);
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                            cmd.Parameters.Add("@TransType", "2");
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@To", BranchID);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                                cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                                cmd.Parameters.Add("@Qty", o.GivenQty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["TripdataSno"].ToString());
                                cmd.Parameters.Add("@TransType", "2");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", BranchID);
                                if (o.GivenQty != "0")
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    if (phonenumber.Length == 10)
                    {
                        string Date = DateTime.Now.ToString("dd/MM/yyyy"); ;
                        WebClient client = new WebClient();

                        //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";

                        string BranchSno = context.Session["CsoNo"].ToString();
                        if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                        {
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }
                        else
                        {
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&sender=VYSNVI&type=1&route=2"; 
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "Your%20indent%20delivery%20for%20today" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }

                        string message = "Dear " + BranchName + "Your  indent delivery for today" + Date + "  ,  " + ProductName + "Total Ltrs =" + TotalQty + " ";

                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", b_bid);
                        cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "OnlineDelivery");
                        cmd.Parameters.Add("@branchname", BranchName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Saved";
                    MsgList.Add(msg);
                    string response = GetJson(MsgList);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                List<string> MsgList = new List<string>();
                string msg = ex.ToString();
                MsgList.Add(msg);
                string response = GetJson(MsgList);
                context.Response.Write(response);
            }
        }
        private void btnFinalDCSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    DateTime dtapril = new DateTime();
                    DateTime dtmarch = new DateTime();
                    int currentyear = ServerDateCurrentdate.Year;
                    int nextyear = ServerDateCurrentdate.Year + 1;
                    if (ServerDateCurrentdate.Month > 3)
                    {
                        string apr = "4/1/" + currentyear;
                        dtapril = DateTime.Parse(apr);
                        string march = "3/31/" + nextyear;
                        dtmarch = DateTime.Parse(march);
                    }
                    if (ServerDateCurrentdate.Month <= 3)
                    {
                        string apr = "4/1/" + (currentyear - 1);
                        dtapril = DateTime.Parse(apr);
                        string march = "3/31/" + (nextyear - 1);
                        dtmarch = DateTime.Parse(march);
                    }
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    //Inventorydetail obj1 = js.Deserialize<Inventorydetail>(title1);

                    string b_bid = obj.BranchID;
                    string DispDate = context.Session["I_Date"].ToString();
                    DateTime dtdispDate = Convert.ToDateTime(DispDate);
                    //cmd = new MySqlCommand("SELECT indents_subtable.IndentNo, SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS totalcost, indents_subtable.unitQty, indents_subtable.LeakQty,indents_subtable.DTripId, indents_subtable.DelTime, productsdata.ProductName, indents.IndentType FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2)");
                    cmd = new MySqlCommand("SELECT SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS totalcost FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2)");
                    cmd.Parameters.Add("@Branchid", b_bid);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                    DataTable dtdeliveryamount = vdm.SelectQuery(cmd).Tables[0];
                    float totdelamount = 0;
                    float.TryParse(dtdeliveryamount.Rows[0]["totalcost"].ToString(), out totdelamount);
                    cmd = new MySqlCommand("SELECT indents.Branch_id, productsdata.ProductName, indents_subtable.DeliveryQty,indents_subtable.UnitCost, indents_subtable.unitQty, indents_subtable.LeakQty ,indents_subtable.ReturnQty, indents.IndentType, indents.IndentNo, productsdata.sno FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2) ORDER BY productsdata.Rank");
                    cmd.Parameters.Add("@Branchid", b_bid);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                    DataTable dtfinaldelivery = vdm.SelectQuery(cmd).Tables[0];
                    DataView view = new DataView(dtfinaldelivery);
                    DataTable dtIndent = view.ToTable(true, "IndentType", "IndentNo");
                    cmd = new MySqlCommand("update Agentdc set IndDate=@IndDate where BranchId=@BranchId and IndDate=@IDate");
                    cmd.Parameters.Add("@BranchId", b_bid);
                    cmd.Parameters.Add("@IndDate", dtdispDate);
                    cmd.Parameters.Add("@IDate", dtdispDate);
                    long DcNo = 0;
                    string socode = context.Session["CsoNo"].ToString();
                    string companycode = "";
                    string gststatecode = "";
                    cmd = new MySqlCommand("SELECT statemastar.gststatecode, branchdata.companycode FROM branchdata INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (branchdata.sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", socode);
                    DataTable dt_GSTNo = vdm.SelectQuery(cmd).Tables[0];
                    if (dt_GSTNo.Rows.Count > 0)
                    {
                        companycode = dt_GSTNo.Rows[0]["companycode"].ToString();
                        gststatecode = dt_GSTNo.Rows[0]["gststatecode"].ToString();
                    }
                    int moduleid = 1;
                    if (vdm.Update(cmd) == 0)
                    {
                       //  cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (stateid = @stateid) and (Companycode = @Companycode)  AND (IndDate BETWEEN @d1 AND @d2)");
                       cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @BranchID) AND (IndDate BETWEEN @d1 AND @d2)");
                       cmd.Parameters.Add("@BranchID", socode);
                        cmd.Parameters.Add("@d1",DateConverter.GetLowDate(dtapril.AddDays(-1)));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtmarch.AddDays(-1)));
                        DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                        string agentdcNo = dtadcno.Rows[0]["Sno"].ToString();

                        cmd = new MySqlCommand("Insert Into Agentdc (BranchId,IndDate,soid,agentdcno,stateid,Companycode,moduleid) Values(@BranchId,@IndDate,@soid,@agentdcno,@stateid,@Companycode,@moduleid)");
                        cmd.Parameters.Add("@BranchId", b_bid);
                        cmd.Parameters.Add("@IndDate", dtdispDate);
                        cmd.Parameters.Add("@soid", socode);
                        cmd.Parameters.Add("@agentdcno", agentdcNo);
                        cmd.Parameters.Add("@stateid", gststatecode);
                        cmd.Parameters.Add("@Companycode", companycode);
                        cmd.Parameters.Add("@moduleid", moduleid);
                        cmd.Parameters.Add("@invoicetype", "Online");
                        DcNo = vdm.insertScalar(cmd);
                        foreach (DataRow dr in dtIndent.Rows)
                        {
                            cmd = new MySqlCommand("Insert Into dcsubTable (DcNo,IndentNo) Values(@DcNo,@IndentNo)");
                            cmd.Parameters.Add("@DcNo", DcNo);
                            cmd.Parameters.Add("@IndentNo", dr["IndentNo"].ToString());
                            vdm.insert(cmd);
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("Select DcNo from Agentdc where BranchId=@BranchId and IndDate=@IDate");
                        cmd.Parameters.Add("@BranchId", b_bid);
                        cmd.Parameters.Add("@IDate", dtdispDate);
                        DataTable dtAgentDc = vdm.SelectQuery(cmd).Tables[0];
                        if (dtAgentDc.Rows.Count > 0)
                        {
                            long.TryParse(dtAgentDc.Rows[0]["DcNo"].ToString(), out DcNo);
                        }
                    }
                    foreach (orderdetail o in obj.data)
                    {
                        int count = 0;
                       
                        foreach (DataRow dr in dtfinaldelivery.Rows)
                        {
                            if (count == 0)
                            {
                                if (o.Productsno == dr["sno"].ToString())
                                {
                                    double deliverqty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out deliverqty);
                                    deliverqty = Math.Round(deliverqty, 2);
                                    double previousleak = 0;
                                    double previousReturn= 0;
                                    double.TryParse(dr["LeakQty"].ToString(), out previousleak);
                                    double.TryParse(dr["ReturnQty"].ToString(), out previousReturn);
                                    previousleak = Math.Round(previousleak, 2);
                                    previousReturn = Math.Round(previousReturn, 2);
                                    double Lqty = 0;
                                    double Rtnqty = 0;
                                    double leakRtntotal = 0;
                                    double.TryParse(o.LeakQty, out Lqty);
                                    double.TryParse(o.RtnQty, out Rtnqty);
                                    Lqty = Math.Round(Lqty, 2);
                                    Rtnqty = Math.Round(Rtnqty, 2);
                                    if (deliverqty > Rtnqty)
                                    {
                                        int indentno = 0;
                                        int Productsno = 0;
                                        double Returnqty = 0;
                                        double.TryParse(o.ReturnQty, out Returnqty);
                                        Returnqty = Math.Round(Returnqty, 2);
                                        double totaldelivery = 0;
                                        if (previousReturn == Rtnqty)
                                        {
                                        }
                                        if (previousReturn < Rtnqty)
                                        {
                                            double totleak = Rtnqty - previousReturn;
                                            totaldelivery = deliverqty - totleak;
                                            totaldelivery = Math.Round(totaldelivery, 2);
                                            int.TryParse(dr["IndentNo"].ToString(), out indentno);
                                            cmd = new MySqlCommand("Update indents_subtable set DeliveryQty=@DeliveryQty,ReturnQty=@returnQty where  IndentNo=@IndentNo and  Product_sno=@Product_sno ");
                                            cmd.Parameters.Add("@IndentNo", indentno);
                                            int.TryParse(o.Productsno, out Productsno);
                                            cmd.Parameters.Add("@Product_sno", Productsno);
                                            cmd.Parameters.Add("@DeliveryQty", totaldelivery);
                                            cmd.Parameters.Add("@returnQty", Rtnqty);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty-@BranchQty where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());

                                            cmd.Parameters.Add("@BranchQty", previousReturn);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty+@BranchQty where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@BranchQty", Rtnqty);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                        }
                                        if (previousReturn > Rtnqty)
                                        {
                                            double totleak = previousReturn - Rtnqty;
                                            totaldelivery = deliverqty + totleak;
                                            totaldelivery = Math.Round(totaldelivery, 2);
                                            int.TryParse(dr["IndentNo"].ToString(), out indentno);
                                            cmd = new MySqlCommand("Update indents_subtable set DeliveryQty=@DeliveryQty,ReturnQty=@ReturnQty where  IndentNo=@IndentNo and  Product_sno=@Product_sno ");
                                            cmd.Parameters.Add("@IndentNo", indentno);
                                            int.TryParse(o.Productsno, out Productsno);
                                            cmd.Parameters.Add("@Product_sno", Productsno);
                                            cmd.Parameters.Add("@DeliveryQty", totaldelivery);
                                            cmd.Parameters.Add("@ReturnQty", Rtnqty);
                                            vdm.Update(cmd);

                                            cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty-@BranchQty where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@BranchQty", previousReturn);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set BranchQty=BranchQty+@BranchQty where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@BranchQty", Rtnqty);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                        }
                                        count++;

                                    }
                                    if (deliverqty > Lqty)
                                    {
                                        int indentno = 0;
                                        int Productsno = 0;
                                        double Returnqty = 0;
                                        double.TryParse(o.ReturnQty, out Returnqty);
                                        Returnqty = Math.Round(Returnqty, 2);
                                        double totaldelivery = 0;
                                        if (previousleak == Lqty)
                                        {
                                        }
                                        if (previousleak < Lqty)
                                        {
                                            double totleak = Lqty - previousleak;
                                            totaldelivery = deliverqty - totleak;
                                            totaldelivery = Math.Round(totaldelivery, 2);
                                            int.TryParse(dr["IndentNo"].ToString(), out indentno);
                                            cmd = new MySqlCommand("Update indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty where  IndentNo=@IndentNo and  Product_sno=@Product_sno ");
                                            cmd.Parameters.Add("@IndentNo", indentno);
                                            int.TryParse(o.Productsno, out Productsno);
                                            cmd.Parameters.Add("@Product_sno", Productsno);
                                            cmd.Parameters.Add("@DeliveryQty", totaldelivery);
                                            cmd.Parameters.Add("@LeakQty", Lqty);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set LeakQty=LeakQty-@leak where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());

                                            cmd.Parameters.Add("@leak", previousleak);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set LeakQty=LeakQty+@leak where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@leak", Lqty);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                        }
                                        if (previousleak > Lqty)
                                        {
                                            double totleak = previousleak - Lqty;
                                            totaldelivery = deliverqty + totleak;
                                            totaldelivery = Math.Round(totaldelivery, 2);
                                            int.TryParse(dr["IndentNo"].ToString(), out indentno);
                                            cmd = new MySqlCommand("Update indents_subtable set DeliveryQty=@DeliveryQty,LeakQty=@LeakQty where  IndentNo=@IndentNo and  Product_sno=@Product_sno ");
                                            cmd.Parameters.Add("@IndentNo", indentno);
                                            int.TryParse(o.Productsno, out Productsno);
                                            cmd.Parameters.Add("@Product_sno", Productsno);
                                            cmd.Parameters.Add("@DeliveryQty", totaldelivery);
                                            cmd.Parameters.Add("@LeakQty", Lqty);
                                            vdm.Update(cmd);

                                            cmd = new MySqlCommand("Update branchproducts set LeakQty=LeakQty-@leak where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@leak", previousleak);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                            cmd = new MySqlCommand("Update branchproducts set LeakQty=LeakQty+@leak where branch_sno=@branch_sno and product_sno=@ProductID");
                                            cmd.Parameters.Add("@branch_sno", context.Session["CsoNo"].ToString());
                                            cmd.Parameters.Add("@leak", Lqty);
                                            cmd.Parameters.Add("@ProductID", o.Productsno);
                                            vdm.Update(cmd);
                                        }
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                    cmd = new MySqlCommand("SELECT SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost) AS totalcost FROM  indents INNER JOIN  indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE (indents.Branch_id = @Branchid) AND (indents.I_date BETWEEN @d1 AND @d2) ");
                    cmd.Parameters.Add("@Branchid", b_bid);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                    DataTable dtUpdatedeliveryamount = vdm.SelectQuery(cmd).Tables[0];
                    float totUpdatedelamount = 0;
                    float.TryParse(dtUpdatedeliveryamount.Rows[0]["totalcost"].ToString(), out totUpdatedelamount);
                    float totbrnchamount = 0;
                    if (totdelamount < totUpdatedelamount)
                    {
                        totbrnchamount = totUpdatedelamount - totdelamount;
                        // totbrnchamount = deliverqty - totleak;
                        cmd = new MySqlCommand("Update branchaccounts set Amount=Amount+@Amount where BranchId=@BranchId");
                        cmd.Parameters.Add("@Amount", totbrnchamount);
                        cmd.Parameters.Add("@BranchId", b_bid);
                        if (vdm.Update(cmd) == 0)
                        {
                            cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                            cmd.Parameters.Add("@Amount", totbrnchamount);
                            cmd.Parameters.Add("@BranchId", b_bid);
                            vdm.insert(cmd);
                        }
                    }
                    if (totdelamount > totUpdatedelamount)
                    {
                        totbrnchamount = totdelamount - totUpdatedelamount;
                        cmd = new MySqlCommand("Update branchaccounts set Amount=Amount-@Amount where BranchId=@BranchId");
                        cmd.Parameters.Add("@Amount", totbrnchamount);
                        cmd.Parameters.Add("@BranchId", b_bid);
                        if (vdm.Update(cmd) == 0)
                        {
                            cmd = new MySqlCommand("Insert Into branchaccounts(Amount,BranchId) values(@Amount,@BranchId)");
                            cmd.Parameters.Add("@Amount", totbrnchamount);
                            cmd.Parameters.Add("@BranchId", b_bid);
                            vdm.insert(cmd);
                        }
                    }
                    foreach (Inventorydetail o in obj.Inventorydetails)
                    {
                        if (o.SNo != null)
                        {
                            cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                            cmd.Parameters.Add("@B_Inv_Sno", o.InvSno);
                            cmd.Parameters.Add("@Qty", o.ReceivedQty);
                            cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                            cmd.Parameters.Add("@From", b_bid);
                            cmd.Parameters.Add("@TransType", "1");
                            cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@To", context.Session["CsoNo"].ToString());
                            if (o.ReceivedQty != "0")
                            {
                                vdm.insert(cmd);
                            }
                            int ReceivedQty = 0;
                            int.TryParse(o.ReceivedQty, out ReceivedQty);
                            cmd = new MySqlCommand("update inventory_monitor set Qty=@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                            int BalanceQty = 0;
                            int.TryParse(o.BalanceQty, out BalanceQty);
                            cmd.Parameters.Add("@Qty", BalanceQty);
                            int InvSno = 0;
                            int.TryParse(o.InvSno, out InvSno);
                            cmd.Parameters.Add("@Inv_Sno", InvSno);
                            cmd.Parameters.Add("@BranchId", b_bid);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                int.TryParse(o.BalanceQty, out BalanceQty);
                                cmd.Parameters.Add("@Qty", BalanceQty);
                                int.TryParse(o.InvSno, out InvSno);
                                cmd.Parameters.Add("@Inv_Sno", InvSno);
                                cmd.Parameters.Add("@BranchId", b_bid);
                                vdm.insert(cmd);
                            }
                            cmd = new MySqlCommand("update inventory_monitor set Qty=Qty+@Qty where Inv_Sno=@Inv_Sno and BranchId=@BranchId");
                            cmd.Parameters.Add("@Qty", ReceivedQty);
                            cmd.Parameters.Add("@Inv_Sno", InvSno);
                            cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                cmd.Parameters.Add("@Qty", ReceivedQty);
                                cmd.Parameters.Add("@Inv_Sno", InvSno);
                                cmd.Parameters.Add("@BranchId", context.Session["CsoNo"].ToString());
                                vdm.insert(cmd);
                            }
                        }
                    }
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.phonenumber, invmaster.InvName, inventory_monitor.Qty FROM branchdata INNER JOIN inventory_monitor ON branchdata.sno = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno WHERE (branchdata.sno = @sno)");
                    cmd.Parameters.Add("@sno", b_bid);
                    DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                    string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                    string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                    string ProductName = "";
                    string InvName = "";
                    double TotalQty = 0;
                    double Salevalue = 0;
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.ReturnQty != "0")
                        {
                            double ReturnQty = 0;
                            double Rate = 0;
                            double Amount = 0;
                            double.TryParse(o.Rate, out Rate);
                            double.TryParse(o.ReturnQty, out ReturnQty);
                            Amount = Rate * ReturnQty;
                            ProductName += o.Product + "=" + Math.Round(ReturnQty, 2) + ";";
                            TotalQty += Math.Round(ReturnQty, 2);
                            Salevalue += Math.Round(Amount, 2);
                        }
                    }
                    foreach (DataRow dr in dtBranchName.Rows)
                    {
                        InvName += dr["InvName"].ToString() + "=" + dr["Qty"].ToString() + ";";
                    }
                    if (phonenumber.Length == 10)
                    {
                        string Date = DateTime.Now.ToString("dd/MM/yyyy"); ;
                        WebClient client = new WebClient();
                        string BranchSno = context.Session["CsoNo"].ToString();
                        if (BranchSno == "4609" || BranchSno == "3625" || BranchSno == "2948" || BranchSno == "172" || BranchSno == "282" || BranchSno == "271" || BranchSno == "174" || BranchSno == "3928" || BranchSno == "285" || BranchSno == "527" || BranchSno == "4607" || BranchSno == "306" || BranchSno == "538" || BranchSno == "2749" || BranchSno == "1801")
                        {
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VYSNVI&to=" + MobNo + "&message=%20" + msg + "&response=Y";
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2"; 
                           // string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VSALES&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }
                        else
                        {
                            string baseurl = "http://roundsms.com/api/sendhttp.php?authkey=Y2U3NGE2MGFkM2V&mobiles=" + phonenumber + "&message=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&sender=VYSNVI&type=1&route=2"; 
                            //string baseurl = "http://www.smsstriker.com/API/sms.php?username=vaishnavidairy&password=vyshnavi@123&from=VFWYRA&to=" + phonenumber + "&msg=Dear%20" + BranchName + "%20DCNO:%20" + DcNo + "%20Your%20indent%20delivery%20for%20today%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs =" + TotalQty + "Sale%20Value%20" + Salevalue + "%20With%20Bal%20Inventory%20" + InvName + "&type=1";
                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            string ResponseID = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                        }
                        string message = "Dear  " + BranchName + " DCNO: " + DcNo + "  Your  indent delivery for today " + Date + "  ,  " + ProductName + "Total  Ltrs =" + TotalQty + " Sale  Value  " + Salevalue + "  With  Bal  Inventory " + InvName + "";

                        // string text = message.Replace("\n", "\n" + System.Environment.NewLine);
                        cmd = new MySqlCommand("insert into smsinfo (agentid,branchid, msg,mobileno,msgtype,branchname,doe) values (@agentid,@branchid,@msg,@mobileno,@msgtype,@branchname,@doe)");
                        cmd.Parameters.Add("@agentid", b_bid);
                        cmd.Parameters.Add("@branchid", context.Session["CsoNo"].ToString());
                        //cmd.Parameters.Add("@mainbranch", Session["SuperBranch"].ToString());
                        cmd.Parameters.Add("@msg", message);
                        cmd.Parameters.Add("@mobileno", phonenumber);
                        cmd.Parameters.Add("@msgtype", "OnlineDelivery");
                        cmd.Parameters.Add("@branchname", BranchName);
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Updated";
                    MsgList.Add(msg);
                    string response = GetJson(MsgList);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                List<string> MsgList = new List<string>();
                string msg = ex.ToString();
                MsgList.Add(msg);
                string response = GetJson(MsgList);
                context.Response.Write(response);
            }
        }
        class ReportResult
        {
            public string sno { set; get; }
            public string BranchName { set; get; }
            public string IndentNo { set; get; }
            public string TotalQty { set; get; }
            public string TotalPrice { set; get; }
            public string IndentDate { set; get; }
            public string Status { set; get; }
            public string DeliveryDate { set; get; }
        }
        VehicleDBMgr vdm;
        MySqlCommand cmd;
        class Branch
        {
            public string b_id { set; get; }
            public string BranchName { set; get; }
            public string mobile { set; get; }
        }
        class Route
        {
            public string rid { set; get; }
            public string RouteName { set; get; }
        }
        private void GetDisTypeChange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Branch> brnch = new List<Branch>();
                string TripID = context.Request["TripId"];
                context.Session["TripID"] = TripID;
                DataTable dtBranch = new DataTable();
                //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SuperBranch INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno WHERE (empmanage.Sno = @UserSno)");
                string Disptype = context.Session["DispType"].ToString();
                if (Disptype == "SO")
                {
                    if (context.Session["SOBranches"] == null)
                    {
                        cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @BranchID) and (branchdata.flag=@flag)");
                        cmd.Parameters.Add("@flag", 1);
                        cmd.Parameters.Add("@BranchID", context.Session["CsoNo"].ToString());
                        dtBranch = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["SOBranches"] = dtBranch;
                    }
                    else
                    {
                        dtBranch = (DataTable)context.Session["SOBranches"];
                    }
                }
                else
                {
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM  dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (dispatch.sno = @TripID) and (branchdata.flag=@flag)");
                    cmd.Parameters.Add("@TripID", TripID);
                    cmd.Parameters.Add("@flag", 1);
                    dtBranch = vdm.SelectQuery(cmd).Tables[0];
                }
                foreach (DataRow dr in dtBranch.Rows)
                {
                    Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                    brnch.Add(b);
                }
                string response = GetJson(brnch);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetRouteNameChange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Branch> brnch = new List<Branch>();
                string TripID = context.Request["TripId"];
                context.Session["TripID"] = TripID;
                //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SuperBranch INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno WHERE (empmanage.Sno = @UserSno)");
                cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,branchdata.phonenumber FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchroutes.Sno = @TripID) and (branchdata.flag=@flag)");
                cmd.Parameters.Add("@TripID", TripID);
                cmd.Parameters.Add("@flag", 1);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtBranch.Rows)
                {
                    Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString(), mobile = dr["phonenumber"].ToString() };
                    brnch.Add(b);
                }
                string response = GetJson(brnch);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void getofferBranchValues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Request["bid"] != null)
                {
                    List<string> MsgList = new List<string>();
                    if (context.Session["userdata_sno"] == null)
                    {
                        string errmsg = "Session Expired";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                    else
                    {
                        string Username = context.Session["userdata_sno"].ToString();
                        string IndentType = context.Request["IndentType"];
                        if (IndentType == "")
                        {
                            IndentType = context.Session["IndentType"].ToString();
                        }
                        if (IndentType == "")
                        {
                            IndentType = "Indent1";
                        }
                        if (IndentType == null)
                        {
                            IndentType = "Indent1";
                        }
                        List<Orderclass> OrderList = new List<Orderclass>();
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                       // cmd = new MySqlCommand("SELECT productsdata.UnitPrice,branchproducts.Rank, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, branchproducts_1.unitprice AS Aunitprice, productsdata.sno FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SubBranch = branchproducts_1.branch_sno AND  productsdata.sno = branchproducts_1.product_sno WHERE (branchproducts_1.branch_sno = @bsno) AND (branchproducts_1.flag = @flag)GROUP BY branchproducts_1.branch_sno, branchproducts_1.unitprice, productsdata.sno, branchproducts_1.flag ORDER BY branchproducts.Rank");
                        cmd = new MySqlCommand("SELECT productsdata.UnitPrice, branchproducts.Rank, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @bsno) AND (branchproducts.flag = @flag) GROUP BY productsdata.sno ORDER BY branchproducts.Rank");
                        cmd.Parameters.Add("@flag", 1);
                        cmd.Parameters.Add("@bsno", context.Session["CsoNo"].ToString());
                        DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];

                        cmd = new MySqlCommand("SELECT offerindent.idoffer_indents, offer_indents_sub.product_id, offer_indents_sub.unit_price, offer_indents_sub.offer_indent_qty FROM (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @agentid) AND (indent_date BETWEEN @d1 AND @d2) AND (IndentType=@indenttype)) offerindent INNER JOIN offer_indents_sub ON offerindent.idoffer_indents = offer_indents_sub.idoffer_indents");
                        cmd.Parameters.Add("@agentid", context.Request["bid"]);
                        cmd.Parameters.Add("@indenttype", IndentType);
                        cmd.Parameters.Add("@d1",DateConverter.GetLowDate(Currentdate));
                        cmd.Parameters.Add("@d2",DateConverter.GetHighDate(Currentdate));
                        DataTable dtoffersindent = vdm.SelectQuery(cmd).Tables[0];

                        cmd = new MySqlCommand("SELECT offerindent.idoffer_indents, offer_indents_sub.product_id, offer_indents_sub.unit_price, offer_indents_sub.offer_indent_qty FROM (SELECT idoffer_indents, idoffers_assignment, salesoffice_id, route_id, agent_id, indent_date, indents_id, IndentType FROM offer_indents WHERE (agent_id = @agentid) AND (indent_date BETWEEN @d1 AND @d2) AND (IndentType=@indenttype)) offerindent INNER JOIN offer_indents_sub ON offerindent.idoffer_indents = offer_indents_sub.idoffer_indents");
                        cmd.Parameters.Add("@agentid", context.Request["bid"]);
                        cmd.Parameters.Add("@indenttype", IndentType);
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate.AddDays(-1)));
                        DataTable dt_Prev_Day_offersindent = vdm.SelectQuery(cmd).Tables[0];

                        cmd = new MySqlCommand("SELECT offers_assignment.idoffers_assignment, offers_assignment.offers_assignment_name, offers_assignment.offer_type, offers_assignment.offer_from, offers_assignment.offer_to, offers_assignment.created_date, offers_assignment.created_by, offers_assignment.status, offers_assignment_sub.id_offers, offers_sub.product_id, offers_sub.offer_product_id, offers_sub.qty_if_above, offers_sub.offer_qty, offers_sub.present_price FROM offers_assignment INNER JOIN offers_assignment_sub ON offers_assignment.idoffers_assignment = offers_assignment_sub.idoffers_assignment INNER JOIN offers_sub ON offers_assignment_sub.id_offers = offers_sub.idoffers WHERE (offers_assignment.status = 1) AND (offers_assignment.salesoffice_id=@bsno) AND (offers_assignment.offer_from <= @d1) AND (offers_assignment.offer_to >= @d1) GROUP BY offers_sub.offer_product_id");
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                        cmd.Parameters.Add("@bsno", context.Session["CsoNo"].ToString());

                        DataTable dtoffers = vdm.SelectQuery(cmd).Tables[0];

                        if (dtoffers.Rows.Count > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in dtoffers.Rows)
                            {
                                


                                foreach (DataRow drbrnchprdt in dtBranch.Select("sno='" + dr["offer_product_id"].ToString() + "'"))
                                {
                                    Orderclass getOrderValue = new Orderclass();
                                    getOrderValue.sno = i++.ToString();
                                    getOrderValue.ProductCode = drbrnchprdt["ProductName"].ToString();
                                    int prodsno = 0;
                                    int.TryParse(drbrnchprdt["sno"].ToString(), out prodsno);
                                    getOrderValue.Productsno = prodsno;
                                    getOrderValue.Qty = 0;
                                    getOrderValue.Total = 0;
                                    if (drbrnchprdt["Units"].ToString() == "ml" || drbrnchprdt["Units"].ToString() == "ltr")
                                    {
                                        getOrderValue.Desciption = "Ltrs";
                                    }
                                    else
                                    {
                                        if (drbrnchprdt["Units"].ToString() == "Nos")
                                        {
                                            getOrderValue.Desciption = "Nos";
                                        }
                                        else
                                        {
                                            getOrderValue.Desciption = "Kgs";
                                        }
                                    }
                                    getOrderValue.Units = drbrnchprdt["Units"].ToString();
                                    getOrderValue.Unitqty = drbrnchprdt["Qty"].ToString();
                                    //string AgentUnitPrice = drbrnchprdt["Aunitprice"].ToString();
                                    string BranchUnitPrice = drbrnchprdt["BUnitPrice"].ToString();
                                    float Rate = 0;
                                    //if (AgentUnitPrice != "0")
                                    //{
                                    //    Rate = (float)drbrnchprdt["Aunitprice"];
                                    //}
                                    if (Rate == 0)
                                    {
                                        Rate = (float)drbrnchprdt["BUnitPrice"];
                                    }
                                    if (Rate == 0)
                                    {
                                        Rate = (float)drbrnchprdt["unitprice"];
                                    }
                                    float Unitqty = (float)drbrnchprdt["Qty"];
                                    float TotalRate = 0;
                                    TotalRate = Rate;
                                    //if (drbrnchprdt["Units"].ToString() == "ml")
                                    //{
                                    //    TotalRate = Rate;
                                    //}
                                    //if (drbrnchprdt["Units"].ToString() == "ltr")
                                    //{
                                    //    TotalRate = Rate;
                                    //}
                                    //if (drbrnchprdt["Units"].ToString() == "gms")
                                    //{
                                    //    TotalRate = Rate;
                                    //}
                                    //if (drbrnchprdt["Units"].ToString() == "kgs")
                                    //{
                                    //    TotalRate = Rate;
                                    //}
                                    getOrderValue.Rate = (float)Rate;
                                    getOrderValue.orderunitRate = (float)TotalRate;
                                    double offerorderqty = 0;
                                    double offerPrevorderqty = 0;
                                    foreach (DataRow drdtoffersindent in dtoffersindent.Select("product_id='" + dr["offer_product_id"].ToString() + "'"))
                                    {
                                        double.TryParse(drdtoffersindent["offer_indent_qty"].ToString(), out offerorderqty);
                                    }
                                    foreach (DataRow drdtoffersindent in dt_Prev_Day_offersindent.Select("product_id='" + dr["offer_product_id"].ToString() + "'"))
                                    {
                                        double.TryParse(drdtoffersindent["offer_indent_qty"].ToString(), out offerPrevorderqty);
                                    }
                                    getOrderValue.PrevQty = offerPrevorderqty;
                                    getOrderValue.orderunitqty = offerorderqty.ToString();
                                    OrderList.Add(getOrderValue);

                                }

                            }

                        }
                        else
                        { 
                            Orderclass getOrderValue = new Orderclass();
                            getOrderValue.sno = "";
                            getOrderValue.ProductCode = "";
                            getOrderValue.Productsno = 0;
                            getOrderValue.Qty = 0;
                            getOrderValue.Total = 0;
                            getOrderValue.Desciption = "";
                            getOrderValue.Units = "";
                            getOrderValue.Unitqty = "";
                            float Rate = 0;
                            float TotalRate = 0;
                            getOrderValue.Rate = (float)Rate;
                            getOrderValue.orderunitRate = (float)TotalRate;
                            getOrderValue.PrevQty = 0;
                            getOrderValue.orderunitqty = "";
                            OrderList.Add(getOrderValue);
                        }
                        string respnceString = GetJson(OrderList);
                        context.Response.Write(respnceString);
                    }
                }
            }
            catch
            {

            }
        }
        private void getBranchValues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Request["bid"] != null)
                {
                    List<string> MsgList = new List<string>();
                    if (context.Session["userdata_sno"] == null)
                    {
                        string errmsg = "Session Expired";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                    else
                    {
                        string Username = context.Session["userdata_sno"].ToString();
                        string DairyStatus = context.Request["DairyStatus"];
                        string IndentType = context.Request["IndentType"];
                        if (IndentType == "")
                        {
                            IndentType = context.Session["IndentType"].ToString();
                        }
                        if (IndentType == "")
                        {
                            IndentType = "Indent1";
                        }
                        if (IndentType == null)
                        {
                            IndentType = "Indent1";
                        }
                        List<Orderclass> OrderList = new List<Orderclass>();
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        #region-------->ORDERS<-----------
                        if (DairyStatus == "Orders")
                        {
                            //By sundeep cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2)");
                            cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, branchproducts_1.Rank,indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.unitprice AS BUnitPrice, branchproducts.branch_sno, branchmappingtable.SuperBranch, indents.I_date, branchproducts_1.unitprice AS SOUnitPrice, branchproducts.flag FROM indents INNER JOIN branchproducts ON indents.Branch_id = branchproducts.branch_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SubBranch INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SuperBranch = branchproducts_1.branch_sno AND  branchproducts.product_sno = branchproducts_1.product_sno LEFT OUTER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo AND branchproducts.product_sno = indents_subtable.Product_sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents.Branch_id = @bsno) AND (indents.IndentType = @IndentType) ORDER BY branchproducts_1.Rank");
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                            cmd.Parameters.Add("@UserName", Username);
                            cmd.Parameters.Add("@IndentType", IndentType);
                            cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                            DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["Orders"] = dtBranch;
                            if (dtBranch.Rows.Count == 0)
                            {
                                cmd = new MySqlCommand("SELECT productsdata.ProductName,branchproducts_1.Rank,productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.unitprice AS BUnitPrice, branchproducts.branch_sno, branchmappingtable.SuperBranch, branchproducts_1.unitprice AS SOUnitPrice FROM indents_subtable INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno AND indents.Branch_id = branchproducts.branch_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SubBranch INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SuperBranch = branchproducts_1.branch_sno AND branchproducts.product_sno = branchproducts_1.product_sno WHERE (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2) AND (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.branch_sno ORDER BY branchproducts_1.Rank");
                                // cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.branch_sno, branchproducts.unitprice AS BUnitPrice FROM  indents_subtable INNER JOIN  productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno WHERE  (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2) AND  (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.product_sno ORDER BY productsdata.sno");
                                //cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno,  indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.branch_sno,  branchproducts.unitprice AS BUnitPrice FROM indents_subtable INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno AND indents.Branch_id = branchproducts.branch_sno WHERE (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2) AND  (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.product_sno ORDER BY productsdata.sno");
                                // cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2)");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate.AddDays(-1)));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate.AddDays(-1)));
                                cmd.Parameters.Add("@flag", 1);
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                if (dtBranch.Rows.Count == 0)
                                {
                                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,branchproducts.Rank, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, branchproducts_1.unitprice AS Aunitprice, productsdata.sno FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SubBranch = branchproducts_1.branch_sno AND  productsdata.sno = branchproducts_1.product_sno WHERE (branchproducts_1.branch_sno = @bsno) AND (branchproducts_1.flag = @flag)GROUP BY branchproducts_1.branch_sno, branchproducts_1.unitprice, productsdata.sno, branchproducts_1.flag ORDER BY branchproducts.Rank");
                                    //cmd = new MySqlCommand("SELECT productsdata.UnitPrice, productsdata.ProductName, productsdata.Units, productsdata.Qty,branchproducts.UnitPrice as BUnitPrice, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.userdata_sno = @UserName) AND (branchproducts.branch_sno = @bsno) AND (branchproducts.flag = @flag)");
                                    //cmd.Parameters.Add("@UserName", Username);
                                    cmd.Parameters.Add("@flag", 1);
                                    cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                    dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                    if (dtBranch.Rows.Count > 0)
                                    {
                                        int i = 1;
                                        foreach (DataRow dr in dtBranch.Rows)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            int prodsno = 0;
                                            int.TryParse(dr["sno"].ToString(), out  prodsno);
                                            getOrderValue.Productsno = prodsno;
                                            getOrderValue.Qty = 0;
                                            getOrderValue.Total = 0;
                                            if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                            {
                                                getOrderValue.Desciption = "Ltrs";
                                            }
                                            else
                                            {
                                                if (dr["Units"].ToString() == "Nos")
                                                {
                                                    getOrderValue.Desciption = "Nos";
                                                }
                                                else
                                                {
                                                    getOrderValue.Desciption = "Kgs";
                                                }
                                            }
                                            getOrderValue.Units = dr["Units"].ToString();
                                            getOrderValue.Unitqty = dr["Qty"].ToString();
                                            string AgentUnitPrice = dr["Aunitprice"].ToString();
                                            string BranchUnitPrice = dr["BUnitPrice"].ToString();
                                            float Rate = 0;
                                            if (AgentUnitPrice != "0")
                                            {
                                                Rate = (float)dr["Aunitprice"];
                                            }
                                            if (Rate == 0)
                                            {
                                                Rate = (float)dr["BUnitPrice"];
                                            }
                                            if (Rate == 0)
                                            {
                                                Rate = (float)dr["unitprice"];
                                            }
                                            float Unitqty = (float)dr["Qty"];
                                            float TotalRate = 0;
                                            TotalRate = Rate;
                                            //if (dr["Units"].ToString() == "ml")
                                            //{
                                            //}
                                            //if (dr["Units"].ToString() == "ltr")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            //if (dr["Units"].ToString() == "gms")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            //if (dr["Units"].ToString() == "kgs")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            getOrderValue.Rate = (float)Rate;
                                            getOrderValue.orderunitRate = (float)TotalRate;
                                            getOrderValue.PrevQty = 0;
                                            getOrderValue.orderunitqty = "";
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                    else
                                    {
                                        Orderclass getOrderValue = new Orderclass();
                                        getOrderValue.sno = "";
                                        getOrderValue.ProductCode = "";
                                        getOrderValue.Productsno = 0;
                                        getOrderValue.Qty = 0;
                                        getOrderValue.Total = 0;
                                        getOrderValue.Desciption = "";
                                        getOrderValue.Units = "";
                                        getOrderValue.Unitqty = "";
                                        float Rate = 0;
                                        float TotalRate = 0;
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        getOrderValue.PrevQty = 0;
                                        getOrderValue.orderunitqty = "";
                                        OrderList.Add(getOrderValue);
                                    }
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                                else
                                {
                                    int i = 1;
                                    foreach (DataRow dr in dtBranch.Rows)
                                    {
                                        Orderclass getOrderValue = new Orderclass();
                                        getOrderValue.sno = i++.ToString();
                                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                                        int prodsno = 0;
                                        int.TryParse(dr["sno"].ToString(),out  prodsno);
                                        getOrderValue.Productsno = prodsno;
                                        float UnitQty = 0;
                                        if (dr["UnitQty"].ToString() == "")
                                        {
                                            UnitQty = 0;
                                        }
                                        else
                                        {
                                            UnitQty = (float)dr["UnitQty"];
                                        }
                                        float qty = (float)UnitQty;
                                        getOrderValue.Qty = (float)Math.Round(qty, 2);
                                        //float Rate = (float)dr["unitCost"];
                                        string BranchUnitPrice = dr["BUnitPrice"].ToString();
                                        if (BranchUnitPrice == "")
                                        {
                                            BranchUnitPrice = "0";
                                        }
                                        float Rate = 0;
                                        if (BranchUnitPrice != "0")
                                        {
                                            Rate = (float)dr["BUnitPrice"];
                                        }
                                        if (Rate == 0)
                                        {

                                            if (dr["SOUnitPrice"].ToString() == "")
                                            {
                                            }
                                            else
                                            {
                                                Rate = (float)dr["SOUnitPrice"];
                                            }
                                        }
                                        if (Rate == 0)
                                        {
                                            Rate = (float)dr["UnitPrice"];
                                        }
                                        float Unitqty = (float)dr["RawQty"];
                                        float TotalRate = 0;
                                        TotalRate = Rate;
                                        //if (dr["Units"].ToString() == "ml")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        //if (dr["Units"].ToString() == "ltr")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        //if (dr["Units"].ToString() == "gms")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        //if (dr["Units"].ToString() == "kgs")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        double Total = 0;
                                        if (dr["Total"].ToString() == "")
                                        {
                                            Total = 0;
                                        }
                                        else
                                        {
                                            Total = (double)dr["Total"];
                                        }
                                        double Dtotal = (double)Total;
                                        getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                        if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                        {
                                            getOrderValue.Desciption = "Ltrs";
                                        }
                                        else
                                        {
                                            if (dr["Units"].ToString() == "Nos")
                                            {
                                                getOrderValue.Desciption = "Nos";
                                            }
                                            else
                                            {
                                                getOrderValue.Desciption = "Kgs";
                                            }
                                        }
                                        getOrderValue.Units = dr["Units"].ToString();
                                        getOrderValue.Unitqty = dr["RawQty"].ToString();
                                        getOrderValue.orderunitqty = "";
                                        float PrevQty = 0;
                                        float.TryParse(dr["UnitQty"].ToString(), out PrevQty);
                                        getOrderValue.PrevQty = Math.Round(PrevQty, 2);

                                        OrderList.Add(getOrderValue);
                                    }
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                            }
                            else
                            {
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    float qty = 0;
                                    float Rate = 0;
                                    Orderclass getOrderValue = new Orderclass();
                                    if (dr["flag"].ToString() == "1")
                                    {
                                        getOrderValue.sno = i++.ToString();
                                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                                        int prodsno = 0;
                                        int.TryParse(dr["sno"].ToString(), out  prodsno);
                                        getOrderValue.Productsno = prodsno;
                                        //qty=(float)dr["UnitQty"];
                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            qty = (float)dr["UnitQty"];
                                        }
                                        else
                                        {
                                            qty = 0;
                                        }
                                        getOrderValue.Qty = (float)Math.Round(qty, 2);
                                        if (dr["unitCost"].ToString() != "")
                                        {
                                            Rate = (float)dr["unitCost"];
                                        }
                                        else
                                        {
                                            float bunitprice = 0;
                                            float.TryParse(dr["BUnitPrice"].ToString(), out bunitprice);
                                            if (bunitprice == 0)
                                            {
                                                float SOunitprice = 0;
                                                float.TryParse(dr["SOUnitPrice"].ToString(), out SOunitprice);
                                                Rate = SOunitprice;
                                            }
                                            else
                                            {
                                                Rate = bunitprice;
                                            }
                                        }
                                        //Rate = (float)dr["unitCost"];
                                        float Unitqty = (float)dr["RawQty"];
                                        float TotalRate = 0;
                                        TotalRate = Rate;
                                        //if (dr["Units"].ToString() == "ml")
                                        //{
                                        //}
                                        //if (dr["Units"].ToString() == "ltr")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        //if (dr["Units"].ToString() == "gms")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        //if (dr["Units"].ToString() == "kgs")
                                        //{
                                        //    TotalRate = Rate;
                                        //}
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        double Dtotal = 0;
                                        if (dr["Total"].ToString() != "")
                                        {
                                            Dtotal = (double)dr["Total"];
                                        }
                                        else
                                        {
                                            Dtotal = 0;
                                        }
                                        // Dtotal = (double)dr["Total"];
                                        getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                        if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                        {
                                            getOrderValue.Desciption = "Ltrs";
                                        }
                                        else
                                        {
                                            if (dr["Units"].ToString() == "Nos")
                                            {
                                                getOrderValue.Desciption = "Nos";
                                            }
                                            else
                                            {
                                                getOrderValue.Desciption = "Kgs";
                                            }
                                        }
                                        getOrderValue.Units = dr["Units"].ToString();
                                        getOrderValue.Unitqty = dr["RawQty"].ToString();
                                        getOrderValue.orderunitqty = dr["UnitQty"].ToString();
                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                    else
                                    {
                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            int prodsno = 0;
                                            int.TryParse(dr["sno"].ToString(), out prodsno);
                                            getOrderValue.Productsno = prodsno;
                                            //qty=(float)dr["UnitQty"];
                                            if (dr["UnitQty"].ToString() != "")
                                            {
                                                qty = (float)dr["UnitQty"];
                                            }
                                            else
                                            {
                                                qty = 0;
                                            }
                                            getOrderValue.Qty = (float)Math.Round(qty, 2);
                                            if (dr["unitCost"].ToString() != "")
                                            {
                                                Rate = (float)dr["unitCost"];
                                            }
                                            else
                                            {
                                                float bunitprice = 0;
                                                float.TryParse(dr["BUnitPrice"].ToString(), out bunitprice);

                                                if (bunitprice == 0)
                                                {
                                                    float SOunitprice = 0;
                                                    float.TryParse(dr["SOUnitPrice"].ToString(), out SOunitprice);
                                                    Rate = SOunitprice;
                                                }
                                                else
                                                {
                                                    Rate = bunitprice;
                                                }
                                            }
                                            //Rate = (float)dr["unitCost"];
                                            float Unitqty = (float)dr["RawQty"];
                                            float TotalRate = 0;
                                            TotalRate = Rate;
                                            //if (dr["Units"].ToString() == "ml")
                                            //{
                                            //}
                                            //if (dr["Units"].ToString() == "ltr")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            //if (dr["Units"].ToString() == "gms")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            //if (dr["Units"].ToString() == "kgs")
                                            //{
                                            //    TotalRate = Rate;
                                            //}
                                            getOrderValue.Rate = (float)Rate;
                                            getOrderValue.orderunitRate = (float)TotalRate;
                                            double Dtotal = 0;
                                            if (dr["Total"].ToString() != "")
                                            {
                                                Dtotal = (double)dr["Total"];
                                            }
                                            else
                                            {
                                                Dtotal = 0;
                                            }
                                            // Dtotal = (double)dr["Total"];
                                            getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                            {
                                                getOrderValue.Desciption = "Ltrs";
                                            }
                                            else
                                            {
                                                if (dr["Units"].ToString() == "Nos")
                                                {
                                                    getOrderValue.Desciption = "Nos";
                                                }
                                                else
                                                {
                                                    getOrderValue.Desciption = "Kgs";
                                                }
                                            }
                                            getOrderValue.Units = dr["Units"].ToString();
                                            getOrderValue.Unitqty = dr["RawQty"].ToString();
                                            getOrderValue.orderunitqty = dr["UnitQty"].ToString();
                                            if (dr["UnitQty"].ToString() != "")
                                            {
                                                OrderList.Add(getOrderValue);
                                            }
                                        }
                                    }
                                }
                                if (OrderList.Count > 0)
                                {
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                                else
                                {
                                    Orderclass getOrderValue = new Orderclass();
                                    getOrderValue.sno = "";
                                    getOrderValue.ProductCode = "";
                                    getOrderValue.Productsno = 0;
                                    getOrderValue.Qty = 0;
                                    getOrderValue.Total = 0;
                                    getOrderValue.Desciption = "";
                                    getOrderValue.Units = "";
                                    getOrderValue.Unitqty = "";
                                    float Rate = 0;
                                    float TotalRate = 0;
                                    getOrderValue.Rate = (float)Rate;
                                    getOrderValue.orderunitRate = (float)TotalRate;
                                    getOrderValue.PrevQty = 0;
                                    getOrderValue.orderunitqty = "";
                                    OrderList.Add(getOrderValue);
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                            }
                        }
                        #endregion
                        if (DairyStatus == "Delivers")
                        {
                            cmd = new MySqlCommand("SELECT MAX(IndentNo) as IndentNo FROM indents where Branch_id = @bsno LIMIT 1");
                            cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                            DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                            string IndentNo = dtIndent.Rows[0]["IndentNo"].ToString();
                            string SalesType = context.Session["Salestype"].ToString();
                            if (SalesType == "Plant")
                            {
                                string RouteID = context.Request["RouteID"];
                                string DispDate = context.Session["DispDate"].ToString();
                                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                                //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status, indents_subtable.Cost as unitprice, productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno) AND (indents_subtable.Status <> 'Delivered') and (indents_subtable.Status <> 'Cancelled' ) AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                                cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType) group By productsdata.ProductName ORDER BY productsdata.Rank ");
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteId) AND (indents_subtable.Status <> 'Delivered') GROUP BY productsdata.ProductName, branchroutes.Sno");
                                //cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno ON dispatch_sub.dispatch_sno = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (indents_subtable.Status <> 'Delivered') AND (dispatch.sno = @dispatchsno)GROUP BY productsdata.ProductName");
                                cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.RouteName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType) GROUP BY productsdata.ProductName ORDER BY productsdata.Rank");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@dispatchsno", RouteID);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtDailyIndent = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, branchproducts.manufact_remaining_qty as RemainQty FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchmappingtable.SuperBranch = @SuperBranch)  GROUP BY branchproducts.product_sno, productsdata.ProductName ");

                                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, ROUND(tripsubdata.Qty, 2) AS Qty FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.RouteID = @RouteID) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)");
                                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@EmpId", context.Session["UserSno"].ToString());
                                DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                                context.Session["Delivers"] = dtBranch;
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    int Branchprdtsno = 0;
                                    int.TryParse(dr["Product_sno"].ToString(), out Branchprdtsno);
                                    foreach (DataRow remainingdr in dtProducts.Rows)
                                    {
                                        int ProductId = 0;
                                        int.TryParse(remainingdr["ProductId"].ToString(), out ProductId);
                                        if (Branchprdtsno == ProductId)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.HdnSno = dr["Sno"].ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            int prodsno = 0;
                                            int.TryParse(dr["Product_sno"].ToString(), out prodsno);
                                            getOrderValue.Productsno = prodsno;
                                            float qty = 0;
                                            float.TryParse(dr["unitQty"].ToString(), out qty);
                                            getOrderValue.Qty = Math.Round(qty, 2);
                                            getOrderValue.Rate = (float)dr["UnitCost"];
                                            string LeakQty = dr["LeakQty"].ToString();
                                            float Dqty = 0;
                                            if (LeakQty != "")
                                            {
                                                float Leak = 0;
                                                float.TryParse(LeakQty, out Leak);
                                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                                                float.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                                                getOrderValue.DQty = Math.Round(Dqty, 2); ;

                                            }
                                            else
                                            {
                                                getOrderValue.LeakQty = 0;
                                                getOrderValue.DQty = Math.Round(qty, 2);
                                            }
                                            getOrderValue.Status = dr["Status"].ToString();
                                            float Rqty = 0;
                                            float.TryParse(remainingdr["Qty"].ToString(), out Rqty);
                                            //float.TryParse(dr["Qty"].ToString(), out Rqty);
                                            getOrderValue.RQty = Rqty;
                                            getOrderValue.Total = 0;
                                            foreach (DataRow drDaily in dtDailyIndent.Rows)
                                            {
                                                int ProSno = 0;
                                                int.TryParse(drDaily["Product_sno"].ToString(), out ProSno);
                                                if (ProSno == Branchprdtsno)
                                                {
                                                    float Iqty = 0;
                                                    float.TryParse(drDaily["Iqty"].ToString(), out Iqty);
                                                    float trqty = Iqty - Dqty; ;
                                                    getOrderValue.TRQty = Math.Round(trqty, 2);
                                                }
                                            }
                                            getOrderValue.orderunitRate = (float)dr["UnitCost"];
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                }
                            }
                            if (SalesType == "SALES OFFICE" || SalesType == "C & F")
                            {
                                string DispDate = context.Session["I_Date"].ToString();
                                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                                //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status, indents_subtable.Cost as unitprice, productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno) AND (indents_subtable.Status <> 'Delivered') and (indents_subtable.Status <> 'Cancelled' ) AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                                cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) group By productsdata.ProductName ORDER BY productsdata.Rank ");
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteId) AND (indents_subtable.Status <> 'Delivered') GROUP BY productsdata.ProductName, branchroutes.Sno");
                                //cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno ON dispatch_sub.dispatch_sno = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (indents_subtable.Status <> 'Delivered') AND (dispatch.sno = @dispatchsno)GROUP BY productsdata.ProductName");
                                cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.RouteName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType ) GROUP BY productsdata.ProductName ORDER BY productsdata.Rank");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@dispatchsno", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtDailyIndent = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, branchproducts.manufact_remaining_qty as RemainQty FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchmappingtable.SuperBranch = @SuperBranch)  GROUP BY branchproducts.product_sno, productsdata.ProductName ");

                                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, ROUND(tripsubdata.Qty, 2) AS Qty FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.RouteID = @RouteID) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)");
                                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@EmpId", context.Session["UserSno"].ToString());
                                DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                                context.Session["Delivers"] = dtBranch;
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    int Branchprdtsno = 0;
                                    int.TryParse(dr["Product_sno"].ToString(), out Branchprdtsno);
                                    foreach (DataRow remainingdr in dtProducts.Rows)
                                    {
                                        int ProductId = 0;
                                        int.TryParse(remainingdr["ProductId"].ToString(), out ProductId);
                                        if (Branchprdtsno == ProductId)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.HdnSno = dr["Sno"].ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            int prodsno = 0;
                                            int.TryParse(dr["Product_sno"].ToString(), out prodsno);
                                            getOrderValue.Productsno = prodsno;
                                            float qty = 0;
                                            float.TryParse(dr["unitQty"].ToString(), out qty);
                                            getOrderValue.Qty = Math.Round(qty, 2);

                                            getOrderValue.Rate = (float)dr["UnitCost"];
                                            string LeakQty = dr["LeakQty"].ToString();
                                            float Dqty = 0;
                                            if (LeakQty != "")
                                            {
                                                float Leak = 0;
                                                float.TryParse(LeakQty, out Leak);
                                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                                                float.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                                                getOrderValue.DQty = Math.Round(Dqty, 2); ;
                                            }
                                            else
                                            {
                                                getOrderValue.LeakQty = 0;
                                                getOrderValue.DQty = Math.Round(qty, 2);
                                            }
                                            getOrderValue.Status = dr["Status"].ToString();
                                            float Rqty = 0;
                                            float.TryParse(remainingdr["Qty"].ToString(), out Rqty);
                                            //float.TryParse(dr["Qty"].ToString(), out Rqty);
                                            getOrderValue.RQty = Rqty;
                                            getOrderValue.Total = 0;
                                            foreach (DataRow drDaily in dtDailyIndent.Rows)
                                            {
                                                int ProSno = 0;
                                                int.TryParse(drDaily["Product_sno"].ToString(), out ProSno);
                                                if (ProSno == Branchprdtsno)
                                                {
                                                    float Iqty = 0;
                                                    float.TryParse(drDaily["Iqty"].ToString(), out Iqty);
                                                    float trqty = Iqty - Dqty; ;
                                                    getOrderValue.TRQty = Math.Round(trqty, 2);
                                                }
                                            }
                                            getOrderValue.orderunitRate = (float)dr["UnitCost"];
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                }
                            }
                            string respnceString = GetJson(OrderList);
                            context.Response.Write(respnceString);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void getFinalDC(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Orderclass> OrderList = new List<Orderclass>();
                if (context.Request["bid"] != null)
                {
                    List<string> MsgList = new List<string>();
                    if (context.Session["userdata_sno"] == null)
                    {
                        string errmsg = "Session Expired";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                    else
                    {
                        string DispDate = context.Session["I_Date"].ToString();
                        DateTime dtdispDate = Convert.ToDateTime(DispDate);
                        cmd = new MySqlCommand("SELECT indents.Branch_id, productsdata.ProductName, SUM(indents_subtable.DeliveryQty) AS dqty, SUM(indents_subtable.unitQty) AS iqty, SUM(indents_subtable.LeakQty) AS leakqty,SUM(indents_subtable.ReturnQty) AS returnqty,indents_subtable.UnitCost, indents.IndentType, productsdata.sno FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bid) AND (indents.I_date BETWEEN @d1 AND @d2) GROUP BY productsdata.ProductName ORDER BY productsdata.Rank");
                        cmd.Parameters.Add("@bid", context.Request["bid"].ToString());
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                        DataTable dtfinaldc = vdm.SelectQuery(cmd).Tables[0];
                        int i = 1;
                        foreach (DataRow dr in dtfinaldc.Rows)
                        {
                            int Branchprdtsno = 0;
                            int.TryParse(dr["sno"].ToString(), out Branchprdtsno);
                            Orderclass getOrderValue = new Orderclass();
                            getOrderValue.sno = i++.ToString();
                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                            int prodsno = 0;
                            int.TryParse(dr["sno"].ToString(), out prodsno);
                            getOrderValue.Productsno = prodsno;
                            float UnitCost = 0;
                            float.TryParse(dr["UnitCost"].ToString(), out UnitCost);
                            getOrderValue.Rate = UnitCost;
                            float qty = 0;
                            float.TryParse(dr["iqty"].ToString(), out qty);
                            getOrderValue.Qty = Math.Round(qty, 2);
                            string LeakQty = dr["leakqty"].ToString();
                            string returnqty = dr["returnqty"].ToString();
                            float Dqty = 0;
                            if (LeakQty != "")
                            {
                                float Leak = 0;
                                float.TryParse(LeakQty, out Leak);
                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                                float.TryParse(dr["dqty"].ToString(), out Dqty);
                                getOrderValue.DQty = Math.Round(Dqty, 2); ;
                            }
                            else
                            {
                                getOrderValue.LeakQty = 0;
                                float.TryParse(dr["dqty"].ToString(), out Dqty);
                                getOrderValue.DQty = Math.Round(Dqty, 2);
                            }
                            if (returnqty != "")
                            {
                                float Returns = 0;
                                float.TryParse(returnqty, out Returns);
                                getOrderValue.returnqty = Math.Round(Returns, 2);
                            }
                            else
                            {
                                getOrderValue.returnqty = 0;
                            }
                            OrderList.Add(getOrderValue);
                        }
                    }
                }
                string respnceString = GetJson(OrderList);
                context.Response.Write(respnceString);
            }
            catch
            {

            }
        }
        public class Orderclass
        {
            public string HdnSno { set; get; }
            public string sno { set; get; }
            public string ProductCode { set; get; }
            public int Productsno { set; get; }
            public double Qty { set; get; }
            public float Rate { set; get; }
            public double Total { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string Units { set; get; }
            public string Unitqty { set; get; }
            public string Desciption { set; get; }
            public string orderunitqty { set; get; }
            public float orderunitRate { set; get; }
            public double LeakQty { set; get; }
            public double DQty { set; get; }
            public double RQty { set; get; }
            public double TRQty { set; get; }
            public double PrevQty { set; get; }
            public double returnqty { set; get; }
        }
        public class redirecturl
        {
            public string responseurl { set; get; }
        }

        private static string GetJson(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(obj);
        }
    }
}