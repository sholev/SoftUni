package bg.softuni.lebank.constants;

public class OutputMessages {

	public static final String INVALID_LOGIN_INFO =
			"Invalid username, try again:";
	
	public static final String ENTER_LOGIN_INFO =
			"Enter valid username and password:";
	
	public static final String OPERATION_NOT_SELECTED = 
			"Deposit or withdrawal wasn't selected.";
	
	public static final String VALID_ID_REQUIRED = 
			"Enter valid id, no whitespace allowed:";
	
	public static final String INVALID_WITHDRAWAL_AMOUNT = 
			"Invalid withdrawal amount. It should be greater than zero.";
	
	public static final String INVALID_CLIENT_ID = 
			"Invalid client id. The user does not have an account, deposit in order to create one.";
	
	public static final String INVALID_WITHDRAWAL_GREATER_THAN_BALLANCE = 
			"Invalid withdrawal amount. It should not be greater than the account ballance.";
	
	public static final String INVALID_WITHDRAWAL_ABOVE_DAILY_LIMIT = 
			"Invalid withdrawal amount. It's above the maximum daily withdrawal amount.";
	
	public static final String INVALID_DEPOSIT_NEGATIVE_OR_ZERO = 
			"Invalid deposit amount. It should be greater than zero.";
	
	public static final String SUCCESSFUL_WITHDRAW = 
			"Successully withdrawn: ";
	
	public static final String SUCCESSFUL_DEPOSIT = 			
			"Successully deposited: ";
	
	public static final String SUCCESSFUL_DEPOSIT_AND_REGISTER = 
			"Successully created an account and deposited " ;
}
