package bg.softuni.lebank.interfaces;

import java.math.BigDecimal;

public interface AccountData {

	String getAccountCurrency();
	
	BigDecimal getBalance();

	String deposit(BigDecimal amount);

	String withdraw(BigDecimal amount);

	Boolean dailyLimitReached(BigDecimal requestedWithdrawal);
}