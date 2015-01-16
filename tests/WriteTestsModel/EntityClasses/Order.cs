﻿#pragma warning disable 0649
//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v4.2.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace WriteTests.EntityClasses
{
	/// <summary>Class which represents the entity 'Order', mapped on table 'LLBLGenProUnitTest.dbo.Order'.</summary>
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		#region Events
		/// <summary>Event which is raised when a property value is changing.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		/// <summary>Event which is raised when a property value changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		
		#region Class Member Declarations
		private System.Int32	_customerId;
		private Nullable<System.Int32>	_employeeId;
		private System.DateTime	_orderDate;
		private System.Int32	_orderId;
		private Nullable<System.DateTime>	_requiredDate;
		private Nullable<System.DateTime>	_shippedDate;
		private System.Guid	_testRunId;
		private EntityRef <Customer> _customer;
		private EntityRef <Employee> _employee;
		private EntitySet <OrderRow> _orderRows;
		#endregion
		
		#region Extensibility Method Definitions
		partial void OnLoaded();
		partial void OnValidate(System.Data.Linq.ChangeAction action);
		partial void OnCreated();
		partial void OnCustomerIdChanging(System.Int32 value);
		partial void OnCustomerIdChanged();
		partial void OnEmployeeIdChanging(Nullable<System.Int32> value);
		partial void OnEmployeeIdChanged();
		partial void OnOrderDateChanging(System.DateTime value);
		partial void OnOrderDateChanged();
		partial void OnOrderIdChanging(System.Int32 value);
		partial void OnOrderIdChanged();
		partial void OnRequiredDateChanging(Nullable<System.DateTime> value);
		partial void OnRequiredDateChanged();
		partial void OnShippedDateChanging(Nullable<System.DateTime> value);
		partial void OnShippedDateChanged();
		partial void OnTestRunIdChanging(System.Guid value);
		partial void OnTestRunIdChanged();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="Order"/> class.</summary>
		public Order()
		{
			_customer = default(EntityRef<Customer>);
			_employee = default(EntityRef<Employee>);
			_orderRows = new EntitySet<OrderRow>(new Action<OrderRow>(this.Attach_OrderRows), new Action<OrderRow>(this.Detach_OrderRows) );
			OnCreated();
		}

		/// <summary>Raises the PropertyChanging event</summary>
		/// <param name="propertyName">name of the property which is changing</param>
		protected virtual void SendPropertyChanging(string propertyName)
		{
			if((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>Raises the PropertyChanged event for the property specified</summary>
		/// <param name="propertyName">name of the property which was changed</param>
		protected virtual void SendPropertyChanged(string propertyName)
		{
			if((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		/// <summary>Attaches this instance to the entity specified as an associated entity</summary>
		/// <param name="entity">The related entity to attach to</param>
		private void Attach_OrderRows(OrderRow entity)
		{
			this.SendPropertyChanging("OrderRows");
			entity.Order = this;
		}
		
		/// <summary>Detaches this instance from the entity specified so it's no longer an associated entity</summary>
		/// <param name="entity">The related entity to detach from</param>
		private void Detach_OrderRows(OrderRow entity)
		{
			this.SendPropertyChanging("OrderRows");
			entity.Order = null;
		}


		#region Class Property Declarations
		/// <summary>Gets or sets the CustomerId field. Mapped on target field 'CustomerID'. </summary>
		public System.Int32 CustomerId
		{
			get	{ return _customerId; }
			set
			{
				if((_customerId != value))
				{
					if(_customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					OnCustomerIdChanging(value);
					SendPropertyChanging("CustomerId");
					_customerId = value;
					SendPropertyChanged("CustomerId");
					OnCustomerIdChanged();
				}
			}
		}

		/// <summary>Gets or sets the EmployeeId field. Mapped on target field 'EmployeeID'. </summary>
		public Nullable<System.Int32> EmployeeId
		{
			get	{ return _employeeId; }
			set
			{
				if((_employeeId != value))
				{
					if(_employee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					OnEmployeeIdChanging(value);
					SendPropertyChanging("EmployeeId");
					_employeeId = value;
					SendPropertyChanged("EmployeeId");
					OnEmployeeIdChanged();
				}
			}
		}

		/// <summary>Gets or sets the OrderDate field. Mapped on target field 'OrderDate'. </summary>
		public System.DateTime OrderDate
		{
			get	{ return _orderDate; }
			set
			{
				if((_orderDate != value))
				{
					OnOrderDateChanging(value);
					SendPropertyChanging("OrderDate");
					_orderDate = value;
					SendPropertyChanged("OrderDate");
					OnOrderDateChanged();
				}
			}
		}

		/// <summary>Gets or sets the OrderId field. Mapped on target field 'OrderID'. </summary>
		public System.Int32 OrderId
		{
			get	{ return _orderId; }
			set
			{
				if((_orderId != value))
				{
					OnOrderIdChanging(value);
					SendPropertyChanging("OrderId");
					_orderId = value;
					SendPropertyChanged("OrderId");
					OnOrderIdChanged();
				}
			}
		}

		/// <summary>Gets or sets the RequiredDate field. Mapped on target field 'RequiredDate'. </summary>
		public Nullable<System.DateTime> RequiredDate
		{
			get	{ return _requiredDate; }
			set
			{
				if((_requiredDate != value))
				{
					OnRequiredDateChanging(value);
					SendPropertyChanging("RequiredDate");
					_requiredDate = value;
					SendPropertyChanged("RequiredDate");
					OnRequiredDateChanged();
				}
			}
		}

		/// <summary>Gets or sets the ShippedDate field. Mapped on target field 'ShippedDate'. </summary>
		public Nullable<System.DateTime> ShippedDate
		{
			get	{ return _shippedDate; }
			set
			{
				if((_shippedDate != value))
				{
					OnShippedDateChanging(value);
					SendPropertyChanging("ShippedDate");
					_shippedDate = value;
					SendPropertyChanged("ShippedDate");
					OnShippedDateChanged();
				}
			}
		}

		/// <summary>Gets or sets the TestRunId field. Mapped on target field 'TestRunID'. </summary>
		public System.Guid TestRunId
		{
			get	{ return _testRunId; }
			set
			{
				if((_testRunId != value))
				{
					OnTestRunIdChanging(value);
					SendPropertyChanging("TestRunId");
					_testRunId = value;
					SendPropertyChanged("TestRunId");
					OnTestRunIdChanged();
				}
			}
		}

		/// <summary>Represents the navigator which is mapped onto the association 'Order.Customer - Customer.Orders (m:1)'</summary>
		public Customer Customer
		{
			get { return _customer.Entity; }
			set
			{
				Customer previousValue = _customer.Entity;
				if((previousValue != value) || (_customer.HasLoadedOrAssignedValue == false))
				{
					this.SendPropertyChanging("Customer");
					if(previousValue != null)
					{
						_customer.Entity = null;
						previousValue.Orders.Remove(this);
					}
					_customer.Entity = value;
					if(value == null)
					{
						_customerId = default(System.Int32);
					}
					else
					{
						value.Orders.Add(this);
						_customerId = value.CustomerId;
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		/// <summary>Represents the navigator which is mapped onto the association 'Order.Employee - Employee.Orders (m:1)'</summary>
		public Employee Employee
		{
			get { return _employee.Entity; }
			set
			{
				Employee previousValue = _employee.Entity;
				if((previousValue != value) || (_employee.HasLoadedOrAssignedValue == false))
				{
					this.SendPropertyChanging("Employee");
					if(previousValue != null)
					{
						_employee.Entity = null;
						previousValue.Orders.Remove(this);
					}
					_employee.Entity = value;
					if(value == null)
					{
						_employeeId = default(Nullable<System.Int32>);
					}
					else
					{
						value.Orders.Add(this);
						_employeeId = value.EmployeeId;
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		/// <summary>Represents the navigator which is mapped onto the association 'OrderRow.Order - Order.OrderRows (m:1)'</summary>
		public EntitySet<OrderRow> OrderRows
		{
			get { return this._orderRows; }
			set { this._orderRows.Assign(value); }
		}
		
		/// <summary>Represents the related field 'this.Customer.CompanyName'</summary>
		public System.String CustomerCompanyName
		{
			get { return this.Customer==null ? default(System.String) : this.Customer.CompanyName; }
			set
			{
				if(this.Customer!=null)
				{
					this.Customer.CompanyName = value;
				}
			}
		}

		/// <summary>Represents the related field 'this.Customer.ContactPerson'</summary>
		public System.String CustomerContactPerson
		{
			get { return this.Customer==null ? default(System.String) : this.Customer.ContactPerson; }
			set
			{
				if(this.Customer!=null)
				{
					this.Customer.ContactPerson = value;
				}
			}
		}

		#endregion
	}
}
#pragma warning restore 0649