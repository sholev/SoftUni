package bg.softuni.lebank.services;

import java.math.BigDecimal;
import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Service;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.CurrencyExchange;

@Service
public class ClientsRepository implements AccountsRepository {

	private Map<String, AccountData> accounts;
	
	public ClientsRepository() {
		
		this.accounts = new HashMap<String, AccountData>();
	}
	
	@Override
	public String getAccountBallance(String owner) {
		
		String balance = "Empty";
		if (this.accounts.containsKey(owner)){
			balance = this.accounts.get(owner).getBalance().setScale(2, BigDecimal.ROUND_DOWN).toString();
			balance = balance + " " + this.accounts.get(owner).getAccountCurrency();
		}
		return balance;
	}
	
	@Override
	public String deposit(String owner, String amount, String currency, CurrencyExchange rate) {
		
		BigDecimal depositAmount = new BigDecimal(amount);
		BigDecimal exchangedAmount = null;
		String output;
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1) {
			output = OutputMessages.INVALID_DEPOSIT_NEGATIVE_OR_ZERO;
		} else {
			if (!this.accounts.containsKey(owner)){
				this.accounts.put(owner, new ClientAccount(depositAmount, currency));
				
				output = OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER
						+ depositAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ currency.toUpperCase();
			} else {
				String accountCurrency = this.accounts.get(owner).getAccountCurrency();
				exchangedAmount = rate.exchangeCurrency(depositAmount, currency, accountCurrency);
				this.accounts.get(owner).deposit(exchangedAmount);
				
				output = OutputMessages.SUCCESSFUL_DEPOSIT
						+ exchangedAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ accountCurrency.toUpperCase();
			}
		}
		
		return output;
	}

	@Override
	public String withdraw(String owner, String amount, String currency, CurrencyExchange rate) {
		
		String accountCurrency = this.accounts.get(owner).getAccountCurrency();
		BigDecimal withdrawalAmount = new BigDecimal(amount);
		BigDecimal exchangedAmmount = rate.exchangeCurrency(withdrawalAmount, currency, accountCurrency);		
		String output;		
		if (exchangedAmmount.compareTo(BigDecimal.ZERO) != 1){
			output = OutputMessages.INVALID_WITHDRAWAL_AMOUNT;
		} else if(!this.accounts.containsKey(owner)){
			output = OutputMessages.INVALID_CLIENT_ID;			
		} else if(exchangedAmmount.compareTo(this.accounts.get(owner).getBalance()) == 1){
			output = OutputMessages.INVALID_WITHDRAWAL_GREATER_THAN_BALLANCE;
		} else if(this.accounts.get(owner).dailyLimitReached(exchangedAmmount)){
			output = OutputMessages.INVALID_WITHDRAWAL_ABOVE_DAILY_LIMIT;
		} else {
			this.accounts.get(owner).withdraw(exchangedAmmount);
			
			output = OutputMessages.SUCCESSFUL_WITHDRAW
					+ exchangedAmmount.setScale(2, BigDecimal.ROUND_DOWN).toString() 
					+ " "
					+ accountCurrency.toUpperCase();
		}
		
		return output;
	}
}
