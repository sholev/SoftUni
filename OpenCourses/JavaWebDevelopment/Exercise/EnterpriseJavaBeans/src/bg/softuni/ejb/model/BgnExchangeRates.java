package bg.softuni.ejb.model;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;

import javax.ejb.Stateless;

import bg.softuni.ejb.interfaces.CurrencyExchange;

@Stateless
public class BgnExchangeRates implements CurrencyExchange{

	private Map<String, Map<String, BigDecimal>> exchangeRates;
	
	public BgnExchangeRates(){		
		this.exchangeRates = new HashMap<String, Map<String, BigDecimal>>();
		Random rng = new Random();
		String[] weekdays = {
				"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
				};
		
		// In C# you could foreach an enum with reflection,
		// how would you do it here? Sucks being a Java noob. T_T
		for (String day : weekdays){
			this.exchangeRates.put(day.toUpperCase(), new HashMap<String, BigDecimal>());
			
			// I'm pretty sure that this is how banks decide their exchange rate, right? :D
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
