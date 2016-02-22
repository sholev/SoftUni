package bg.softuni.lebank.interfaces;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public interface CurrencyExchange {

	BigDecimal getExchangeRate(LocalDateTime date, String currency);
}
