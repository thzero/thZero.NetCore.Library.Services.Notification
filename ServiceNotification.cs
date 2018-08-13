/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2017 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;
using System.Threading.Tasks;

namespace thZero.Services
{
	public abstract class ServiceNotification<T> : IServiceNotification
		where T : ServiceNotificationConfig
	{
		#region Public Methods
		public bool Initialize(ServiceNotificationConfig config)
		{
			Enforce.AgainstNull(() => config);

			Config = (T)config;
			return true;
		}

		public abstract Task<string> Registration(string token, params string[] topics);
		public abstract Task<bool> Send(string topic, NotificationMessageType type, string message, string title);
		public abstract Task<bool> Subscribe(string token, string topic);
		#endregion

		#region Public Properties
		public T Config { get; private set; }
		#endregion
	}
}