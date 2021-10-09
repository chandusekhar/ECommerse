using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Messages.Events
{
	public class IntegrationBaseEvent
	{
		public IntegrationBaseEvent()
		{
			CreationDate = DateTime.UtcNow;
		}

		public IntegrationBaseEvent(Guid id, DateTime createDate)
		{
			CreationDate = createDate;
		}
		public DateTime CreationDate { get; private set; }
	}
}
