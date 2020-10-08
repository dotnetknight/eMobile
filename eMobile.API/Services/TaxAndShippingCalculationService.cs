using eMobile.API.Requests;
using eMobile.Models.Responses;
using System.Collections.Generic;

namespace eMobile.API.Services
{
    public class TaxAndShippingCalculationService
    {
        public TaxAndShippingTotalCalculatorResponse Calculate(TaxAndShippingCalculationRequest request)
        {
            var shippingAndTaxCalculation = new List<BasShippingCalculator>
            {
                new ShippingCalculator(new Shipping{ Height = request.Height, Width = request.Width, Length = request.Length }),
                new TaxCalculator(new Shipping{ Height = request.Height, Width = request.Width, Length = request.Length })
            };

            var total = new TaxAndShippingTotalCalculator(shippingAndTaxCalculation).CalculateTotalShippingCost();

            return new TaxAndShippingTotalCalculatorResponse
            {
                Total = total
            };
        }
    }

    public abstract class BasShippingCalculator
    {
        protected Shipping _shipping { get; private set; }

        public BasShippingCalculator(Shipping shipping)
        {
            _shipping = shipping;
        }

        public abstract double CalculateShipping();
    }

    public class Shipping
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class TaxCalculator : BasShippingCalculator
    {
        public TaxCalculator(Shipping report) : base(report) { }

        public override double CalculateShipping() => (_shipping.Length * _shipping.Width * _shipping.Height * 0.2) / 80;
    }

    public class ShippingCalculator : BasShippingCalculator
    {
        public ShippingCalculator(Shipping report) : base(report) { }

        public override double CalculateShipping() => (_shipping.Length * _shipping.Width * _shipping.Height * 1.5) / 60;
    }

    public class TaxAndShippingTotalCalculator
    {
        private readonly IEnumerable<BasShippingCalculator> _basShippingCalculator;

        public TaxAndShippingTotalCalculator(IEnumerable<BasShippingCalculator> basShippingCalculator)
        {
            _basShippingCalculator = basShippingCalculator;
        }

        public double CalculateTotalShippingCost()
        {
            double totalShipping = 0;

            foreach (var devCalc in _basShippingCalculator)
            {
                totalShipping += devCalc.CalculateShipping();
            }

            return totalShipping;
        }
    }
}