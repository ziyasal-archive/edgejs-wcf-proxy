#r "System.ServiceModel.dll"

using System.Threading.Tasks;
using System;
using System.ServiceModel;

public class Startup {
	public async Task < object > Invoke(dynamic input) {
		return this.IsAlive((string)input.url, (bool)input.useTcp);
	}
	bool IsAlive(string endpointUrl, bool useTcp) {
		if (useTcp) {
			return ServiceHelper.IsAliveTcp(endpointUrl);
		}
		return ServiceHelper.IsAliveHttp(endpointUrl);
	}
}

[ServiceContract]
public interface ISoaService {
	[OperationContract]
	bool IsAlive();

	[OperationContract(Name = "IsServiceAlive")]
	bool IsAlive(string serviceUri);
}
static class ServiceHelper {
	public static bool IsAliveHttp(string endpointUrl) {
		bool response = false;

		ChannelFactory <ISoaService> channelFactory = null;
		try {
			channelFactory = new ChannelFactory <ISoaService> (new BasicHttpBinding(BasicHttpSecurityMode.None), new EndpointAddress(endpointUrl));

			ISoaService soaService = channelFactory.CreateChannel();

			if (soaService != null) {
				response = soaService.IsAlive();
			}
			channelFactory.Close();
		} catch (Exception exception) {
			//TODO:
		} finally {
			if (channelFactory != null) channelFactory.Abort();
		}

		return response;

	}
	public static bool IsAliveTcp(string endpointUrl) {
		bool response = false;

		ChannelFactory <ISoaService> channelFactory = null;

		try {
			channelFactory = new ChannelFactory <ISoaService> (new NetTcpBinding(SecurityMode.None), new EndpointAddress(endpointUrl));

			ISoaService soaService = channelFactory.CreateChannel();

			if (soaService != null) {
				response = soaService.IsAlive();
			}
			channelFactory.Close();
		} catch (Exception exception) {

			//TODO:
		} finally {
			if (channelFactory != null) channelFactory.Abort();
		}

		return response;
	}
}
