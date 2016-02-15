package bg.softuni.ejb.interfaces;

import java.math.BigDecimal;
import java.time.LocalDateTime;

import javax.ejb.Local;

@Local
public interface CurrencyExchange {

	BigDecimal getExchangeRate(LocalDateTime date, String currency);
}
