package bg.softuni.lebank.interfaces;

import java.math.BigDecimal;

public interface AccountData {

	String getAccountCurrency();
	
	BigDecimal getBalance();

	void deposit(BigDecimal amount);

	void withdraw(BigDecimal amount);

	Boolean dailyLimitReached(BigDecimal requestedWithdrawal);
}