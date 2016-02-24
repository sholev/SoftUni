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
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1){
			output = "Invalid deposit amount. It should be greater than zero.";
		} else {
			if (!this.accounts.containsKey(owner)){
				this.accounts.put(owner, new ClientAccount(depositAmount, currency));
				
				output = "Successully created an account and deposited " 
						+ depositAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ currency.toUpperCase();
			} else {
				String accountCurrency = this.accounts.get(owner).getAccountCurrency();
				exchangedAmount = rate.exchangeCurrency(depositAmount, currency, accountCurrency);
				this.accounts.get(owner).deposit(exchangedAmount);
				
				output = "Successully deposited: " 
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
			output = "Invalid withdrawal amount. It should be greater than zero.";
		} else if(!this.accounts.containsKey(owner)){
			output = "Invalid user. The user does not have an account, deposit in order to create one.";			
		} else if(exchangedAmmount.compareTo(this.accounts.get(owner).getBalance()) == 1){
			output = "Invalid withdrawal amount. It should not be greater than the account ballance.";
		} else if(this.accounts.get(owner).dailyLimitReached(exchangedAmmount)){
			output = "Invalid withdrawal amount. It's above the maximum daily withdrawal amount.";
		} else {
			this.accounts.get(owner).withdraw(exchangedAmmount);
			
			output = "Successully withdrawn: " 
					+ exchangedAmmount.setScale(2, BigDecimal.ROUND_DOWN).toString() 
					+ " "
					+ accountCurrency.toUpperCase();
		}
		
		return output;
	}
}
