package bg.softuni.lebank.entities;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;

import bg.softuni.lebank.interfaces.CurrencyExchange;

public class BgnExchange implements CurrencyExchange{

	private Map<String, Map<String, BigDecimal>> exchangeRates;
	
	public BgnExchange(){		
		this.exchangeRates = new HashMap<String, Map<String, BigDecimal>>();
		Random rng = new Random();
		String[] weekdays = {
				"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
				};
		
		for (String day : weekdays){
			this.exchangeRates.put(day.toUpperCase(), new HashMap<String, BigDecimal>());
			
			this.exchangeRates.get(day.toUpperCase()).put("usd", new BigDecimal(1.73 + rng.nextDouble()));		
			this.exchangeRates.get(day.toUpperCase()).put("eur", new BigDecimal(1.96 + rng.nextDouble()));
			this.exchangeRates.get(day.toUpperCase()).put("gbp", new BigDecimal(2.49 + rng.nextDouble()));
			this.exchangeRates.get(day.toUpperCase()).put("bgn", new BigDecimal(1.0));
		}
	}
	
	@Override
	public BigDecimal getExchangeRate(LocalDateTime date, String currency){
		
		String weekday = date.getDayOfWeek().toString();
		
		return this.exchangeRates.get(weekday).get(currency);
	}

}