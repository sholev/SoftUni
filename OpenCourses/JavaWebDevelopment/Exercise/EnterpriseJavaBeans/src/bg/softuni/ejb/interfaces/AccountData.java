package bg.softuni.ejb.interfaces;

import java.math.BigDecimal;

public interface AccountData {

	BigDecimal getBalance();

	void deposit(BigDecimal amount);

	void withdraw(BigDecimal amount);

	Boolean dailyLimitReached(BigDecimal requestedWithdrawal);

}