package bg.softuni.lebank.entities;

import java.math.BigDecimal;
import java.time.LocalDateTime;

import bg.softuni.lebank.interfaces.AccountData;


public class ClientAccount implements AccountData {
	
	private BigDecimal totalBalance;
	private BigDecimal dailyWithdrawal;
	private String lastWithdrawalDay;
	
	public ClientAccount(){
		this.totalBalance = BigDecimal.ZERO;
		this.dailyWithdrawal = BigDecimal.ZERO;
		this.lastWithdrawalDay = LocalDateTime.now().getDayOfWeek().toString();
	}
	
	public ClientAccount(BigDecimal initialDeposit){
		this.totalBalance = initialDeposit;
		this.dailyWithdrawal = BigDecimal.ZERO;
		this.lastWithdrawalDay = LocalDateTime.now().getDayOfWeek().toString();
	}
	
	@Override
	public BigDecimal getBalance(){
		return this.totalBalance;
	}
	
	@Override
	public void deposit(BigDecimal amount){
		this.checkForWithdrawalLimitReset();
		
		this.totalBalance = this.totalBalance.add(amount);		
	}
	
	@Override
	public void withdraw(BigDecimal amount){
		this.checkForWithdrawalLimitReset();
		
		this.dailyWithdrawal = this.dailyWithdrawal.add(amount);	
		this.totalBalance = this.totalBalance.subtract(amount);		
	}
	
	@Override
	public Boolean dailyLimitReached(BigDecimal requestedWithdrawal){
		BigDecimal dailyLimit = this.totalBalance.divide(new BigDecimal("2"));
		
		return this.dailyWithdrawal.add(requestedWithdrawal).compareTo(dailyLimit) == 1;
	}
	
	private void checkForWithdrawalLimitReset(){
		String today = LocalDateTime.now().getDayOfWeek().toString();
		if (!this.lastWithdrawalDay.equals(today)){
			this.dailyWithdrawal = BigDecimal.ZERO;
			this.lastWithdrawalDay = today;
		}
	}
}
