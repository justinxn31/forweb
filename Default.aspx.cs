using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.DirectoryServices;




 
public partial class _Default : System.Web.UI.Page
{
   Datacon1 dataconn = new Datacon1();
   Datacon dataconn1 = new Datacon();

    protected void Page_Load(object sender, EventArgs e)
   {
       UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
     
       Session["ID"] = this.tbid.Text;
       Session["PW"] = this.tbpd.Text;
//       HttpCookie cookieID = new HttpCookie("ID");
//       cookieID.Value = tbid.Text;
//       Response.AppendCookie(cookieID);
//HttpCookie cookiePW = new HttpCookie("PW");
//cookiePW.Value = tbpd.Text;
//       cookieID.Expires = DateTime.Now.AddDays(1);//cookie時間設定 範例為存活時間為創建後的1年

//       Response.AppendCookie(cookiePW);
       //this.Label3.Text = Session["ID"].ToString();


        //if (!IsPostBack)
        //{
          
        //    ///////////////////////////
        //    //SqlConnection con = dataconn.getcon();
        //    //SqlDataAdapter myadapter1 = new SqlDataAdapter("select * from sales ORDER BY ID DESC", con);
        //    //DataTable dt = new DataTable();
        //    ////foreach (DataTable table in dt.Tables){
        //    ////  DataRow[] row3 = dt.Tables[0].Select();



        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());
        //    //dt.Rows.Add(dt.NewRow());

     
        //    //GridView1.DataSource = dt;
        //    //GridView1.DataBind();




        //    //dataconn.ecadabindinfostring(GridView1, "select * from sales ORDER BY ID DESC", "ID");


        //    for (int i = 0; i < 7; i++)
        //    {
        //        DropDownList dl1 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList1");

        //        dataconn.ecDropDownList(dl1, "select * from time", "name", "id");

        //        DropDownList dl2 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList2");
        //        dataconn.ecDropDownList(dl2, "select * from area", "area", "id");

        //        DropDownList dl3 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList3");
        //        dataconn.ecDropDownList(dl3, "select * from division", "division", "id");

        //        DropDownList dl4 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList4");
        //        dataconn.ecDropDownList(dl4, "select * from title", "title", "id");

        //        DropDownList dl5 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList5");
        //        dataconn.ecDropDownList(dl5, "select * from level1", "level1", "id");

        //        DropDownList dl6 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList6");
        //        dataconn.ecDropDownList(dl6, "select * from mproduct", "mproduct", "id");

        //        DropDownList dl7 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList7");
        //        dataconn.ecDropDownList(dl7, "select * from product1", "product1", "id");

        //        DropDownList dl8 = (DropDownList)GridView1.Rows[i].FindControl("DropdownList8");
        //        dataconn.ecDropDownList(dl8, "select * from product2", "product2", "id");

        //    }
        //    //////////////////////////////////////////
            




        //}
    }



    protected void Button2_Click(object sender, EventArgs e)
    {


            this.getcom(2);
        
        
        
    }
    //==============================登录控制============================
    private void getcom(int i)
    {

        SqlConnection con = dataconn1.getcon();
        con.Open();
        SqlCommand com = con.CreateCommand();
      
        switch (i)
        {  
            
          
            case 1:
                 com.CommandText = "select count(*) from admin where employeen='" + tbid.Text + "' and ID='" + tbpd.Text + "' and rank='1'";
                int count3 = Convert.ToInt32(com.ExecuteScalar());
                if (count3 > 0)
                {
                    Session["Login"] = "OK";
              
                    Application["ID"] = tbid.Text;
                    Application["PWD"] = tbpd.Text;
                    Response.Redirect("adminh1.aspx");
                }
                  else
                {
                    Response.Write("<script lanuage=javascript>alert('此帳號為管理者帳號，請先確定所選部門是否正確。在確定ID或密碼輸入是否有誤!');location='javascript:history.go(-1)'</script>");
                    return;
                }
                break;

            case 2:
              
                com.CommandText = "select  *  from employee where eme='" + tbid.Text + "' and password='" + tbpd.Text + "'";

                //int count2 = Convert.ToInt32(com.ExecuteScalar());
                SqlDataReader lrd = com.ExecuteReader();




              if ( lrd.Read())
                {

                    //HttpCookie cookieu_name = new HttpCookie("u_name");
                    //cookieu_name.Value = lrd["employeen"].ToString();
                    //Response.Cookies.Add(cookieu_name);

                    Session["u_name"] = lrd["employeen"].ToString();
                    Session["u_rank"] = lrd["rank"].ToString();
                    Session["eme"] = lrd["eme"].ToString();
                    if (lrd["eme"].ToString() == "adminh")
                    {
                        Session["Login"] = "OK";
                        Session["h"] = "h";
                  
                        Application["ID"] = tbid.Text;
                        Application["PWD"] = tbpd.Text;
                        Response.Redirect("adminh1.aspx");

                    }
                    else if( lrd["eme"].ToString() == "admins")
                    {
                        Session["s"] = "s";
                        Session["Login"] = "OK";
                        Application["ID"] = tbid.Text;
                        Application["PWD"] = tbpd.Text;
                        Response.Redirect("adminh1.aspx");
                    }
                    else if (lrd["eme"].ToString() == "human")
                    {
                        Session["Login"] = "OK";
                        Application["ID"] = tbid.Text;
                        Application["PWD"] = tbpd.Text;
                        Response.Redirect("human1.aspx");
                    }
                    else if (lrd["rank"].ToString() == "1" )
                    {
                        //Application["d2"] = "1";
                      //Session["Login"] = "OK";
                      //Session["SelTitle"] = "健康管理事業部";
                      //HttpCookie cookied2 = new HttpCookie("d2");
                      //cookied2.Value = "1";
                      //HttpCookie cookieSelTitle = new HttpCookie("SelTitle");
                      //cookieSelTitle.Value = "健康管理事業部";
                      //Response.Cookies.Add(cookieSelTitle);

                      //string loginID = this.tbid.Text.Trim();
                      //  HttpCookie cookieID = new HttpCookie("ID",loginID);
                  //    cookieID.Value = tbid.Text;
                     // Response.Cookies.Add(cookieID);
                      //HttpCookie aCookie = new HttpCookie("ID1");
                      //aCookie.Value = tbid.Text;
                      //aCookie.Expires = DateTime.Now.AddDays(1);
                      //Response.Cookies.Add(aCookie);

                     


                      //HttpCookie cookiePW = new HttpCookie("PW");
                      //cookiePW.Value = tbpd.Text;
                      //cookieID.Expires = DateTime.Now.AddDays(1);//cookie時間設定 範例為存活時間為創建後的1年
             
                      //Response.Cookies.Add(cookiePW);

                        //Application["ID"] = tbid.Text;
                        //Application["PWD"] = tbpd.Text;
                        Application["d2"] = "1";
                        Session["Login"] = "OK";
                        Session["SelTitle"] = "健康管理事業部";

                        Application["ID"] = tbid.Text;
                        Application["PWD"] = tbpd.Text;
                        Response.Redirect("breport.aspx");



                        Response.Redirect("breport.aspx");
                    }
                    else if (lrd["rank"].ToString() == "2")
                    {
                        Application["d2"] = "2";
                        Session["SelTitle"] = "特殊醫療事業部";
                        Session["Login"] = "OK";
                        Application["ID"] = tbid.Text;
                        Application["PWD"] = tbpd.Text;
                        Response.Redirect("sreport.aspx");
                    }
                }
                else
                {
                    Response.Write("<script lanuage=javascript>alert('ID或密碼有誤!');location='javascript:history.go(-1)'</script>");
                    return;
                }
                break;



            case 3:
                com.CommandText = "select count(*) from admin where employeen='" + tbid.Text + "' and ID='" + tbpd.Text + "' and rank='2'";
                int count4 = Convert.ToInt32(com.ExecuteScalar());
                if (count4 > 0)
                {
                    Session["Login"] = "OK";
                    Application["ID"] = tbid.Text;
                    Application["PWD"] = tbpd.Text;
                    Response.Redirect("admins.aspx");
                }
                else
                {
                    Response.Write("<script lanuage=javascript>alert('此帳號為管理者帳號，請先確定所選部門是否正確。在確定ID或密碼輸入是否有誤!');location='javascript:history.go(-1)'</script>");
                    return;
                }
                break;

            case 4:
                com.CommandText = "select count(*) from admin where employeen='" + tbid.Text + "' and ID='" + tbpd.Text + "' and rank='3'";
                int count5 = Convert.ToInt32(com.ExecuteScalar());
                if (count5 > 0)
                {
                    Session["Login"] = "OK";
                    Application["ID"] = tbid.Text;
                    Application["PWD"] = tbpd.Text;
                    Response.Redirect("human.aspx");
                }
                else
                {
                    Response.Write("<script lanuage=javascript>alert('此帳號為管理者帳號，請先確定所選部門是否正確。在確定ID或密碼輸入是否有誤!');location='javascript:history.go(-1)'</script>");
                    return;
                }
                break;








        }
        con.Close();
    }
    }
