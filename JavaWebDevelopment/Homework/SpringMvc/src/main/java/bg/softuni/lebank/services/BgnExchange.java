package bg.softuni.lebank.services;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;

import org.springframework.stereotype.Service;

import bg.softuni.lebank.interfaces.CurrencyExchange;

@Service
public class BgnExchange implements CurrencyExchange {

	private Map<String, Map<String, BigDecimal>> exchangeRates;
	
	public BgnExchange() {		
		this.exchangeRates = new HashMap<String, Map<String, BigDecimal>>();
		Random rng = new Random();
		String[] weekdays = {
				"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
				};
		
		for (String day : weekdays) {
			this.exchangeRates.put(day.toUpperCase(), new HashMap<String, BigDecimal>());
			
			this.exchangeRates.get(day.toUpperCase()).put("USD", new BigDecimal(1.73 + rng.nextDouble()));		
			this.exchangeRates.get(day.toUpperCase()).put("EUR", new BigDecimal(1.96 + rng.nextDouble()));
			this.exchangeRates.get(day.toUpperCase()).put("GBP", new BigDecimal(2.49 + rng.nextDouble()));
			this.exchangeRates.get(day.toUpperCase()).put("BGN", new BigDecimal(1.0));
		}
	}

	@Override
	public BigDecimal exchangeCurrency(BigDecimal amount, String inCurrency, String outCurrency) {
		
		String weekday = LocalDateTime.now().getDayOfWeek().toString().toUpperCase();		
		BigDecimal bgnCurrency = amount.multiply(this.exchangeRates.get(weekday).get(inCurrency));
		// Not sure what sort of rounding should be used.  I'm guessing that the
		// losses should be for the client of the bank and not the bank. :D
		BigDecimal outputCurrency = bgnCurrency.divide(this.exchangeRates.get(weekday).get(outCurrency), 7, RoundingMode.DOWN);
				
		return outputCurrency;
	}
}