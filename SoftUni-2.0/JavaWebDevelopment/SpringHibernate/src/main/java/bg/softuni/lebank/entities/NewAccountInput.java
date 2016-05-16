package bg.softuni.lebank.entities;

public class NewAccountInput {
	
	private String selectedUser;

	private String initialBallance;
	
	private String initialCurrency;
	
	public String getSelectedUser() {
		return selectedUser;
	}
	
	public String getInitialBallance() {
		return initialBallance;
	}
	
	public String getInitialCurrency() {
		return initialCurrency;
	}

	public void setSelectedUser(String selectedUser) {
		this.selectedUser = selectedUser;
	}
	
	public void setInitialBallance(String initialBallance) {
		this.initialBallance = initialBallance;
	}
	
	public void setInitialCurrency(String initialCurrency) {
		this.initialCurrency = initialCurrency;
	}	
}
