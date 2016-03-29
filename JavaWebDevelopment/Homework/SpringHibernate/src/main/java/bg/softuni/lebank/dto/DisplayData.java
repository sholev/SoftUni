package bg.softuni.lebank.dto;

public class DisplayData {

	private String accountId;
	private String accountBallance;
	private String accountCurrency;
	
	public DisplayData(String accountId, String accountBallance, String accountCurrency) {
		this.setAccountId(accountId);
		this.setAccountBallance(accountBallance);
		this.setAccountCurrency(accountCurrency);
	}
	
	public String getAccountId() {
		return accountId;
	}
	
	public String getAccountBallance() {
		return accountBallance;
	}
	
	public String getAccountCurrency() {
		return accountCurrency;
	}
	
	public void setAccountId(String accountId) {
		this.accountId = accountId;
	}
	
	public void setAccountBallance(String accountBallance) {
		this.accountBallance = accountBallance;
	}
	
	public void setAccountCurrency(String accountCurrency) {
		this.accountCurrency = accountCurrency;
	}	
}
