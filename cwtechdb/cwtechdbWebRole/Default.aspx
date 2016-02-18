<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cwtechdbWebRole._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="" style="border: 1px solid #808080; margin-top: 20px; width: 200px; border-radius: 3px">
            <div style="border-bottom: 1px solid #808080; padding: 5px; background: #14739d; color: #fff;">Tools</div>
            <ul id="toolTree" class="tools"></ul>
        </div>
        <div class="" style="position: absolute; left: 30%; top: 20%; border: 1px solid #999; width: 300px; max-height: 342px; border-radius: 3px">
            <div style="border-bottom: 1px solid #999; padding: 5px; background: #14739d; color: #fff;">Add Tools</div>
            <div style="position: relative;">
                <div style="padding: 10px">
                    <!--select tool type-->
                    <asp:Button Text="Get tool types" ID="gm_gettooltypes" class="btn btn-primary btn-sm" runat="server" Style="" OnClick="gm_gettooltypes_Click" />

                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Style="margin-top: 10px"></asp:DropDownList>

                </div>
                <!--select tools -->
                <div style="border-top: 1px solid #ccc; padding: 10px; overflow: auto; max-height: 160px">
                    <%--<ul class="toolList">
                        <li>
                            <input type="checkbox" id="" name="toolList" value="Tool 2" />
                            <span>Tool 1</span></li>
                        <li>
                            <label>
                                <input type="checkbox" id="" name="toolList" value="Tool 2" />
                                <span>Tool 2</span>
                            </label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                    </ul>--%>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>

                </div>
                <div style="width: 100%; padding: 10px; margin-top: 10px; clear: both; border-top: 1px solid #ccc">
                    <input id="btnAddTools" type="button"  class="btn btn-primary btn-sm" value="Add Tool"  />
                </div>
            </div>
            <%--<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>--%>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
        
            $("#btnAddTools").click(function () {

                var tools = [];

                $("#MainContent_CheckBoxList1").find("input:checked").each(function (i, val) {
                    tools.push($(this).val());
                });

                for (var i = 0; i < tools.length; i++) {
                    $('<li />', { html: tools[i] }).appendTo('#toolTree');
                }
                
                //var toolSelected = $('input[name=toolList]:checked');
                //var tools = [];

                //toolSelected.each(function () {
                //    tools.push($(this).val());
                //})
                
                ////for (var i = 0; i < tools.length; i++) {
                ////    $('<li />', { html: tools[i] }).appendTo('#toolTree');
                ////}

            })            
        })

    </script>

</asp:Content>

