package bg.softuni.lebank.services;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Service;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.CurrencyExchange;

@Service
public class AccountDataRepository implements AccountsRepository {

	private Map<String, AccountData> accounts;
	
	public AccountDataRepository() {
		
		this.accounts = new HashMap<String, AccountData>();
	}
	
	@Override
	public String getAccountCurrency(String accountId) {
		String currency = "";
		if (this.accounts.containsKey(accountId)){
			currency = this.accounts.get(accountId).getAccountCurrency();
		}
		
		return currency;
	}
	
	@Override
	public String[] getMultipleAccountsCurrency(String[] accountIds) {
		List<String> output = new ArrayList<>();
		for (String id : accountIds) {
			output.add(this.getAccountCurrency(id));
		}
		
		return output.toArray(new String[output.size()]);
	}
	
	@Override
	public String getAccountBalance(String accointId) {
		
		String balance = "Empty";
		if (this.accounts.containsKey(accointId)){
			balance = this.accounts.get(accointId).getBalance().setScale(2, BigDecimal.ROUND_DOWN).toString();
			balance = balance + " " + this.accounts.get(accointId).getAccountCurrency();
		}
		return balance;
	}
	
	@Override
	public String[] getMultipleAccountsBallance(String[] accountIds) {
		List<String> output = new ArrayList<>();
		for (String id : accountIds) {
			output.add(this.getAccountBalance(id));
		}
		
		return output.toArray(new String[output.size()]);
	}
	
	@Override
	public String deposit(String accountId, String amount, String currency, CurrencyExchange rate) {
		
		BigDecimal depositAmount = new BigDecimal(amount);
		BigDecimal exchangedAmount = null;
		String output;
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1) {
			output = OutputMessages.INVALID_DEPOSIT_NEGATIVE_OR_ZERO;
		} else {
			if (!this.accounts.containsKey(accountId)){
				this.accounts.put(accountId, new ClientAccount(depositAmount, currency));
				
				output = OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER
						+ depositAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ currency.toUpperCase();
			} else {
				String accountCurrency = this.accounts.get(accountId).getAccountCurrency();
				exchangedAmount = rate.exchangeCurrency(depositAmount, currency, accountCurrency);
				this.accounts.get(accountId).deposit(exchangedAmount);
				
				output = OutputMessages.SUCCESSFUL_DEPOSIT
						+ exchangedAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ accountCurrency.toUpperCase();
			}
		}
		
		return output;
	}

	@Override
	public String withdraw(String accountId, String amount, String currency, CurrencyExchange rate) {
		
		String accountCurrency = this.accounts.get(accountId).getAccountCurrency();
		BigDecimal withdrawalAmount = new BigDecimal(amount);
		BigDecimal exchangedAmmount = rate.exchangeCurrency(withdrawalAmount, currency, accountCurrency);		
		String output;		
		if (exchangedAmmount.compareTo(BigDecimal.ZERO) != 1){
			output = OutputMessages.INVALID_WITHDRAWAL_AMOUNT;
		} else if(!this.accounts.containsKey(accountId)){
			output = OutputMessages.INVALID_CLIENT_ID;			
		} else if(exchangedAmmount.compareTo(this.accounts.get(accountId).getBalance()) == 1){
			output = OutputMessages.INVALID_WITHDRAWAL_GREATER_THAN_BALLANCE;
		} else if(this.accounts.get(accountId).dailyLimitReached(exchangedAmmount)){
			output = OutputMessages.INVALID_WITHDRAWAL_ABOVE_DAILY_LIMIT;
		} else {
			this.accounts.get(accountId).withdraw(exchangedAmmount);
			
			output = OutputMessages.SUCCESSFUL_WITHDRAW
					+ exchangedAmmount.setScale(2, BigDecimal.ROUND_DOWN).toString() 
					+ " "
					+ accountCurrency.toUpperCase();
		}
		
		return output;
	}
}
