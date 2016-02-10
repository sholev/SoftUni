package bg.softuni.ejb.model;

import java.math.BigDecimal;
import java.util.*;

import javax.ejb.Stateful;

import bg.softuni.ejb.interfaces.Accounting;

@Stateful
public class BankingAccount implements Accounting{

	private Map<String, BigDecimal> accounts;
	
	public BankingAccount(){		
		this.accounts = new HashMap<String, BigDecimal>();
	}
	
	@Override
	public String getAccountBallance(String owner) {
		String balance = "0";
		if (this.accounts.containsKey(owner)){
			balance = this.accounts.get(owner).toString();
		}
		return balance;
	}
	
	@Override
	public String Deposit(String owner, String amount) {
		BigDecimal depositAmount = new BigDecimal(amount);
		String output;
		
		if (depositAmount.compareTo(BigDecimal.ZERO) != 1){
			output = "Invalid deposit amount. It should be greater than zero.";
		} else {
			if (!this.accounts.containsKey(owner)){
				this.accounts.put(owner, depositAmount);
			} else {
				BigDecimal amountAfterDeposit = this.accounts.get(owner).add(depositAmount);
				this.accounts.put(owner, amountAfterDeposit);
			}
			
			output = "Successully deposited: " + depositAmount.toString();
		}
		
		return output;
	}

	@Override
	public String Withdraw(String owner, String amount) {
		BigDecimal withdrawalAmount = new BigDecimal(amount);
		String output;
		
		if (withdrawalAmount.compareTo(BigDecimal.ZERO) != 1){
			output = "Invalid withdrawal amount. It should be greater than zero.";
		} else if(!this.accounts.containsKey(owner)){
			output = "Invalid user. The user does not have an account, deposit in order to create one.";			
		} else if(withdrawalAmount.compareTo(this.accounts.get(owner)) == 1){
			output = "Invalid withdrawal amount. It should not be greater than the account ballance.";
		} else if(withdrawalAmount.compareTo(this.accounts.get(owner).divide(new BigDecimal("2"))) == 1){
			output = "Invalid withdrawal amount. Each withdrawal is limited to half the account availability.";
		} else {
			
			BigDecimal amountAfterWithdrawal = this.accounts.get(owner).subtract(withdrawalAmount);
			this.accounts.put(owner, amountAfterWithdrawal);
			
			output = "Successully withdrawn: " + withdrawalAmount.toString();
		}
		
		return output;
	}

}
