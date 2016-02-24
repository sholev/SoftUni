package bg.softuni.lebank.services;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Service;

import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.CurrencyExchange;

@Service
public class ClientsRepository implements AccountsRepository{

	private Map<String, AccountData> accounts;
	private String accountCurrency;
	
	public ClientsRepository(){
		this.accountCurrency = "bgn";
		this.accounts = new HashMap<String, AccountData>();
	}
	
	@Override
	public String getAccountCurrency() {
		return this.accountCurrency.toUpperCase();
	}
	
	@Override
	public String getAccountBallance(String owner) {
		String balance = "0";
		if (this.accounts.containsKey(owner)){
			balance = this.accounts.get(owner).getBalance().setScale(2, BigDecimal.ROUND_DOWN).toString();
		}
		return balance;
	}
	
	@Override
	public String deposit(String owner, String amount, String currency, CurrencyExchange rate) {
		BigDecimal depositAmount = new BigDecimal(amount);
		BigDecimal exchangeRate = rate.getExchangeRate(LocalDateTime.now(), currency);
		depositAmount = depositAmount.multiply(exchangeRate);
		
		String output;		
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1){
			output = "Invalid deposit amount. It should be greater than zero.";
		} else {
			if (!this.accounts.containsKey(owner)){
				this.accounts.put(owner, new ClientAccount(depositAmount));
			} else {
				this.accounts.get(owner).deposit(depositAmount);
			}
			
			output = "Successully deposited: " 
					+ depositAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
					+ " "
					+ this.accountCurrency.toUpperCase();
		}
		
		return output;
	}

	@Override
	public String withdraw(String owner, String amount, String currency, CurrencyExchange rate) {
		BigDecimal withdrawalAmount = new BigDecimal(amount);
		BigDecimal exchangeRate = rate.getExchangeRate(LocalDateTime.now(), currency);
		withdrawalAmount = withdrawalAmount.multiply(exchangeRate);
		
		String output;
		
		if (withdrawalAmount.compareTo(BigDecimal.ZERO) != 1){
			output = "Invalid withdrawal amount. It should be greater than zero.";
		} else if(!this.accounts.containsKey(owner)){
			output = "Invalid user. The user does not have an account, deposit in order to create one.";			
		} else if(withdrawalAmount.compareTo(this.accounts.get(owner).getBalance()) == 1){
			output = "Invalid withdrawal amount. It should not be greater than the account ballance.";
		} else if(this.accounts.get(owner).dailyLimitReached(withdrawalAmount)){
			output = "Invalid withdrawal amount. It's above the maximum daily withdrawal amount.";
		} else {
			this.accounts.get(owner).withdraw(withdrawalAmount);
			
			output = "Successully withdrawn: " 
					+ withdrawalAmount.setScale(2, BigDecimal.ROUND_DOWN).toString() 
					+ " "
					+ this.accountCurrency.toUpperCase();
		}
		
		return output;
	}
}
