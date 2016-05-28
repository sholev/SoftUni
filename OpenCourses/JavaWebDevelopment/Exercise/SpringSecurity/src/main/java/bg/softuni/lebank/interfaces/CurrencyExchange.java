package bg.softuni.lebank.interfaces;

import java.math.BigDecimal;

public interface CurrencyExchange {

	BigDecimal exchangeCurrency(BigDecimal amount, String inCurrency, String outCurrency);
}
