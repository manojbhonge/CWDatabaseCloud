<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="cwtechdb" generation="1" functional="0" release="0" Id="29ee7cd9-8be0-45c0-807a-ce0dfc1869f5" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="cwtechdbGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="cwtechdbWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/cwtechdb/cwtechdbGroup/LB:cwtechdbWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="cwtechdbWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/cwtechdb/cwtechdbGroup/MapcwtechdbWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="cwtechdbWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/cwtechdb/cwtechdbGroup/MapcwtechdbWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:cwtechdbWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapcwtechdbWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapcwtechdbWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="cwtechdbWebRole" generation="1" functional="0" release="0" software="E:\cloudApp\CWDatabaseCloud\cwtechdb\cwtechdb\csx\Debug\roles\cwtechdbWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;cwtechdbWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;cwtechdbWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="cwtechdbWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="cwtechdbWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="cwtechdbWebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="25d45f18-c2a1-41b9-97c0-3dbc3daf18bc" ref="Microsoft.RedDog.Contract\ServiceContract\cwtechdbContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="f6cc6581-8315-4ab6-b153-7f17f5048c26" ref="Microsoft.RedDog.Contract\Interface\cwtechdbWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/cwtechdb/cwtechdbGroup/cwtechdbWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>