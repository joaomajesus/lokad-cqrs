#region (c) 2010 Lokad Open Source - New BSD License 

// Copyright (c) Lokad 2010, http://www.lokad.com
// This code is released as Open Source under the terms of the New BSD Licence

#endregion

using System;
using System.Collections.Generic;

namespace Lokad.Cqrs
{
	/// <summary>
	/// Deserialized message representation
	/// </summary>
	public class MessageEnvelope
	{
		/// <summary>
		/// Type of the contract behind the message
		/// </summary>
		public readonly Type ContractType;
		
		
		/// <summary>
		/// Message content
		/// </summary>
		public readonly object Content;

		public readonly string EnvelopeId;

		readonly IDictionary<string, object> _attributes = new Dictionary<string, object>();

		public MessageEnvelope(IDictionary<string,object> attributes, object content, Type contractType)
		{
		
			ContractType = contractType;
			_attributes = attributes;
			Content = content;
		}

		public Maybe<TData> GetAttributeValue<TData>(string name)
			where TData : struct
		{
			return _attributes.GetValue(name).Convert(o => (TData)o);
		}

		public ICollection<KeyValuePair<string,object>> GetAllAttributes()
		{
			return _attributes;
		}
	}

	public static class EnvelopeAttribute
	{
		public const string CreatedUtc = "CreatedUtc";
	}

	

	//public sealed class MessageEnvelope
	//{
	//    public readonly string EnvelopeId;
	//    public readonly MessageItem[] Messages;
	//    public readonly IDictionary<string, object> Attributes = new Dictionary<string, object>();

	
	//}

	//public sealed class MessageItem
	//{
	//    public readonly string MessageId;
	//    public readonly string Contract;
	//    public readonly Type MappedType;
	//    public readonly object Content;
	//    public readonly IDictionary<string, object> Attributes = new Dictionary<string, object>();
	//}
}