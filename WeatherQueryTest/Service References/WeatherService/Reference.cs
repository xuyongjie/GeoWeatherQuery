﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherQueryTest.WeatherService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WeatherInfo", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class WeatherInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int SuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WeatherJsonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaNameField;
        
        private System.DateTime RefreshTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string WeatherJson {
            get {
                return this.WeatherJsonField;
            }
            set {
                if ((object.ReferenceEquals(this.WeatherJsonField, value) != true)) {
                    this.WeatherJsonField = value;
                    this.RaisePropertyChanged("WeatherJson");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string AreaId {
            get {
                return this.AreaIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaIdField, value) != true)) {
                    this.AreaIdField = value;
                    this.RaisePropertyChanged("AreaId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string AreaName {
            get {
                return this.AreaNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaNameField, value) != true)) {
                    this.AreaNameField = value;
                    this.RaisePropertyChanged("AreaName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.DateTime RefreshTime {
            get {
                return this.RefreshTimeField;
            }
            set {
                if ((this.RefreshTimeField.Equals(value) != true)) {
                    this.RefreshTimeField = value;
                    this.RaisePropertyChanged("RefreshTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WeatherService.WeatherServiceSoap")]
    public interface WeatherServiceSoap {
        
        // CODEGEN: Generating message contract since element name GetWeatherByGeoResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetWeatherByGeo", ReplyAction="*")]
        WeatherQueryTest.WeatherService.GetWeatherByGeoResponse GetWeatherByGeo(WeatherQueryTest.WeatherService.GetWeatherByGeoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetWeatherByGeo", ReplyAction="*")]
        System.Threading.Tasks.Task<WeatherQueryTest.WeatherService.GetWeatherByGeoResponse> GetWeatherByGeoAsync(WeatherQueryTest.WeatherService.GetWeatherByGeoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeatherByGeoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeatherByGeo", Namespace="http://tempuri.org/", Order=0)]
        public WeatherQueryTest.WeatherService.GetWeatherByGeoRequestBody Body;
        
        public GetWeatherByGeoRequest() {
        }
        
        public GetWeatherByGeoRequest(WeatherQueryTest.WeatherService.GetWeatherByGeoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeatherByGeoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public double longitude;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double latitude;
        
        public GetWeatherByGeoRequestBody() {
        }
        
        public GetWeatherByGeoRequestBody(double longitude, double latitude) {
            this.longitude = longitude;
            this.latitude = latitude;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeatherByGeoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeatherByGeoResponse", Namespace="http://tempuri.org/", Order=0)]
        public WeatherQueryTest.WeatherService.GetWeatherByGeoResponseBody Body;
        
        public GetWeatherByGeoResponse() {
        }
        
        public GetWeatherByGeoResponse(WeatherQueryTest.WeatherService.GetWeatherByGeoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeatherByGeoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WeatherQueryTest.WeatherService.WeatherInfo GetWeatherByGeoResult;
        
        public GetWeatherByGeoResponseBody() {
        }
        
        public GetWeatherByGeoResponseBody(WeatherQueryTest.WeatherService.WeatherInfo GetWeatherByGeoResult) {
            this.GetWeatherByGeoResult = GetWeatherByGeoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeatherServiceSoapChannel : WeatherQueryTest.WeatherService.WeatherServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherServiceSoapClient : System.ServiceModel.ClientBase<WeatherQueryTest.WeatherService.WeatherServiceSoap>, WeatherQueryTest.WeatherService.WeatherServiceSoap {
        
        public WeatherServiceSoapClient() {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WeatherQueryTest.WeatherService.GetWeatherByGeoResponse WeatherQueryTest.WeatherService.WeatherServiceSoap.GetWeatherByGeo(WeatherQueryTest.WeatherService.GetWeatherByGeoRequest request) {
            return base.Channel.GetWeatherByGeo(request);
        }
        
        public WeatherQueryTest.WeatherService.WeatherInfo GetWeatherByGeo(double longitude, double latitude) {
            WeatherQueryTest.WeatherService.GetWeatherByGeoRequest inValue = new WeatherQueryTest.WeatherService.GetWeatherByGeoRequest();
            inValue.Body = new WeatherQueryTest.WeatherService.GetWeatherByGeoRequestBody();
            inValue.Body.longitude = longitude;
            inValue.Body.latitude = latitude;
            WeatherQueryTest.WeatherService.GetWeatherByGeoResponse retVal = ((WeatherQueryTest.WeatherService.WeatherServiceSoap)(this)).GetWeatherByGeo(inValue);
            return retVal.Body.GetWeatherByGeoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WeatherQueryTest.WeatherService.GetWeatherByGeoResponse> WeatherQueryTest.WeatherService.WeatherServiceSoap.GetWeatherByGeoAsync(WeatherQueryTest.WeatherService.GetWeatherByGeoRequest request) {
            return base.Channel.GetWeatherByGeoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WeatherQueryTest.WeatherService.GetWeatherByGeoResponse> GetWeatherByGeoAsync(double longitude, double latitude) {
            WeatherQueryTest.WeatherService.GetWeatherByGeoRequest inValue = new WeatherQueryTest.WeatherService.GetWeatherByGeoRequest();
            inValue.Body = new WeatherQueryTest.WeatherService.GetWeatherByGeoRequestBody();
            inValue.Body.longitude = longitude;
            inValue.Body.latitude = latitude;
            return ((WeatherQueryTest.WeatherService.WeatherServiceSoap)(this)).GetWeatherByGeoAsync(inValue);
        }
    }
}
