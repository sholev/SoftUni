package bg.softuni.lebank.services;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.entities.DatabaseOperation;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountService;
import bg.softuni.lebank.interfaces.AccountStorage;
import bg.softuni.lebank.interfaces.CurrencyExchange;
import bg.softuni.lebank.interfaces.OperationStorage;

@Service
public class AccountDataService implements AccountService {

	private CurrencyExchange rate;
	
	private Map<String, AccountData> accounts;

	private AccountStorage dbAccounts;
	
	private OperationStorage dbOperations;
	
	@Autowired
	public AccountDataService(CurrencyExchange rate, AccountStorage dbAccounts, OperationStorage dbOperations) {
		this.rate = rate;
		this.accounts = dbAccounts.getAccounts();
		this.dbAccounts = dbAccounts;
		this.dbOperations = dbOperations;
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
			//balance = balance + " " + this.accounts.get(accointId).getAccountCurrency();
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
	public String deposit(String accountId, String amount, String currency, String currentUser) {
		
		BigDecimal depositAmount = new BigDecimal(amount);
		BigDecimal exchangedAmount = null;
		long accountNo = Long.parseLong(accountId.split("-")[1]);
		String output;		
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1) {
			output = OutputMessages.INVALID_DEPOSIT_NEGATIVE_OR_ZERO;
		} else {
			if (!this.accounts.containsKey(accountId)){
				this.accounts.put(accountId, new ClientAccount(depositAmount, currency));
				DatabaseOperation operationData = new DatabaseOperation(accountNo, accountId, "deposit", amount, currency, currentUser);
				this.dbOperations.addOperation(operationData);
				
				output = OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER
						+ depositAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ currency.toUpperCase();
			} else {
				String accountCurrency = this.accounts.get(accountId).getAccountCurrency();
				exchangedAmount = this.rate.exchangeCurrency(depositAmount, currency, accountCurrency);
				String amountAfterOperation = this.accounts.get(accountId).deposit(exchangedAmount);

				this.dbAccounts.updateAccount(accountId, amountAfterOperation);
				DatabaseOperation operationData = new DatabaseOperation(accountNo, accountId, "deposit", amount, currency, currentUser);
				this.dbOperations.addOperation(operationData);
				output = OutputMessages.SUCCESSFUL_DEPOSIT
						+ exchangedAmount.setScale(2, BigDecimal.ROUND_DOWN).toString()
						+ " "
						+ accountCurrency.toUpperCase();				
			}
		}
		
		return output;
	}

	@Override
	public String withdraw(String accountId, String amount, String currency, String currentUser) {
		
		String accountCurrency = this.accounts.get(accountId).getAccountCurrency();
		BigDecimal withdrawalAmount = new BigDecimal(amount);
		BigDecimal exchangedAmmount = this.rate.exchangeCurrency(withdrawalAmount, currency, accountCurrency);		
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
			String amountAfterOperation = this.accounts.get(accountId).withdraw(exchangedAmmount);
			
			this.dbAccounts.updateAccount(accountId, amountAfterOperation);
			long accountNo = Long.parseLong(accountId.split("-")[1]);
			DatabaseOperation operationData = new DatabaseOperation(accountNo, accountId, "withdrawal", amount, currency, currentUser);
			this.dbOperations.addOperation(operationData);
			output = OutputMessages.SUCCESSFUL_WITHDRAW
					+ exchangedAmmount.setScale(2, BigDecimal.ROUND_DOWN).toString() 
					+ " "
					+ accountCurrency.toUpperCase();
		}
		
		return output;
	}
}
