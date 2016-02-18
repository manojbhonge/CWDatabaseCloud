<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cwtechdbWebRole._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="" style="border: 1px solid #808080; margin-top: 20px; width: 200px; border-radius: 3px">
            <div style="border-bottom: 1px solid #808080; padding: 5px; background: #14739d; color: #fff;">Tools</div>
            <ul class="tools">
                <li>Tool 1</li>
                <li>Tool 2</li>
            </ul>
        </div>
        <div class="" style="position: absolute; left: 30%; top: 20%; border: 1px solid #999; width: 300px; height: 342px; border-radius: 3px; overflow: hidden">
            <div style="border-bottom: 1px solid #999; padding: 5px; background: #14739d; color: #fff;">Add Tools</div>
            <div style="position: relative; over">
                <div style="padding: 10px">
                    <!--select tool type-->
                    <select>
                        <option>Ball Nose</option>
                        <option>Hog Nose</option>
                    </select>
                </div>
                <!--select tools -->
                <div style="border-top: 1px solid #ccc; padding: 10px; overflow-y: auto">
                    <ul class="toolList">
                        <li>
                            <input type="checkbox" id="" />
                            <span>Tool 1</span></li>
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
                        <li>
                            <label>
                                <input type="checkbox" id="" />
                                <span>Tool 1</span>
                            </label>
                        </li>
                    </ul>
                </div>
                <div style="width: 100%; padding: 10px; margin-top: 10px; clear: both; border-top: 1px solid #ccc">
                    <asp:Button Text="Add Tool" class="btn btn-primary btn-sm" runat="server" Style="float: right" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
