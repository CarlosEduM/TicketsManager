﻿using System;
using System.Collections.Generic;

namespace DesafioMbLabs.Models
{
    /// <summary>
    /// Represents a transaction made by a user
    /// </summary>
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime BuyDateTime { get; set; }

        public DateTime PaymentDateTime { get; set; }

        private List<Ticket> _tickets;
        public List<Ticket> Tickets
        {
            get { return _tickets; }
            set
            {
                if (value.Count < 1)
                    throw new ArgumentException("Number of tickets bougth must be greater than 0");

                _tickets = value;
            }
        }

        public PaymentStatus PaymentStatus { get; set; }

        public User Buyer { get; set; }

        public PaymentForm PaymentForm { get; set; }

        public double TotalPrice { get; set; }

        /// <summary>
        /// Create a void Transaction
        /// </summary>
        public Transaction()
        {

        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="ticketsEvent">transaction related tickets</param>
        /// <param name="tickets">Tickets to be bought</param>
        /// <param name="buyer">Buyer of tickets</param>
        /// <param name="paymentForm">Paymento form of transaction</param>
        /// <exception cref="ArgumentException"></exception>
        public Transaction(Event ticketsEvent, List<Ticket> tickets, User buyer, PaymentForm paymentForm)
        {
            BuyDateTime = DateTime.UtcNow;
            Buyer = buyer;
            PaymentForm = paymentForm;
            TotalPrice = ticketsEvent.TicketPrice * tickets.Count;

            Tickets = tickets;
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="id">Transaction id</param>
        /// <param name="buyDateTime">Date and time of buy</param>
        /// <param name="paymentDateTime">Date and time of payment</param>
        /// <param name="tickets">Tickets bought</param>
        /// <param name="paymentStatus">Payment status</param>
        /// <param name="buyer">Who bought the ticket</param>
        /// <param name="paymentForm">Payment form of transaction</param>
        /// <param name="totalPrice">Total price of transaction</param>
        public Transaction(int id, DateTime buyDateTime, DateTime paymentDateTime, List<Ticket> tickets,
            PaymentStatus paymentStatus, User buyer, PaymentForm paymentForm, double totalPrice)
        {
            Id = id;
            BuyDateTime = buyDateTime;
            PaymentDateTime = paymentDateTime;
            Tickets = tickets;
            PaymentStatus = paymentStatus;
            Buyer = buyer;
            PaymentForm = paymentForm;
            TotalPrice = totalPrice;
        }
    }
}