package bg.softuni.lebank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.entities.NewAccountInput;
import bg.softuni.lebank.entities.OperationInput;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.UserAccounts;

@Controller
public class BankingController {
		
	@Autowired
	private UserAccounts userAccounts;
	
	@Autowired
	private AccountsRepository accountsRepository;
	
	@RequestMapping(value = {"/", "/registry"}, method = RequestMethod.GET)
	public String registry(Model model) {
		String username = SecurityContextHolder.getContext().getAuthentication().getName();	
		String output = OutputMessages.RGISTRY_INFORMATION;
		
		// TODO: Facade this.
		String[] accountIds = this.userAccounts.getIds(username);	
		DisplayData[] displayData = null;
		if (accountIds != null) {
			String[] ballancePerId = this.accountsRepository.getMultipleAccountsBallance(accountIds);		
			String[] currencyPerId = this.accountsRepository.getMultipleAccountsCurrency(accountIds);
			displayData = new DisplayData[accountIds.length];		
			for	(int i = 0; i < displayData.length; i++) {
				displayData[i] = new DisplayData(accountIds[i], ballancePerId[i], currencyPerId[i]);
			}
		} else {
				output = OutputMessages.NO_ACCOUNTS_TO_DISPLAY;
		}
		
		model.addAttribute("displayData", displayData);
		model.addAttribute("output", output);
		
		return "registry";
	}
	
	@RequestMapping(value = "/operation")
	public String operation(Model model, @ModelAttribute(value = "SpringWeb") OperationInput input) {
		String username = SecurityContextHolder.getContext().getAuthentication().getName();	
		String[] accountIds = this.userAccounts.getIds(username);	
		model.addAttribute("accountIds", accountIds);
		String output = "Enter operation information:";
		
		if (accountIds == null) {
			output = OutputMessages.NO_ACCOUNTS_TO_OPERATE;
		} else {
			String amount = input.getOperationAmmount();
			String accountId = input.getSelectedAccountId();
			String operation = input.getSelectedOperation();
			String currency = input.getSelectedCurrency();
			
			Boolean amountIsValidNumber = amount != null && amount.matches("-?\\d+(\\.\\d+)?");
			Boolean amountIsEmptyString = amount != null && amount.equals("");
			if (operation != null && operation.equals("deposit") && amountIsValidNumber){
				output = this.accountsRepository.deposit(accountId, amount, currency);
			} else if (operation != null && operation.equals("withdraw") && amountIsValidNumber){
				output = this.accountsRepository.withdraw(accountId, amount, currency);
			} else if (amountIsEmptyString){
				output = OutputMessages.INVALID_OPERATION;
			}	
		}

		model.addAttribute("output", output);		
		if (output.toLowerCase().contains("success")) {
			return this.registry(model);
		}
		
		return "operation";
	}
	
	@RequestMapping(value = "/newAccount")
	public String newAccount(Model model, @ModelAttribute(value = "SpringWeb") NewAccountInput input) {
		String output = OutputMessages.ENTER_NEW_ACCOUNT_INFO;
		String username = SecurityContextHolder.getContext().getAuthentication().getName();
		
		String[] accountIds = this.userAccounts.getIds(username);
		int accountNumber = accountIds == null ? 1 : accountIds.length + 1;
		model.addAttribute("accountNumber", accountNumber);
		
		String initialBallance = input.getInitialBallance();
		String initialCurrency = input.getInitialCurrency();
		String accountKey = username + "-" + accountNumber;
		if (initialBallance == "") {
			output = OutputMessages.INVALID_INITIAL_BALLANCE;
		} else if (initialBallance != null) {
			output = this.accountsRepository.deposit(accountKey, initialBallance, initialCurrency);
			this.userAccounts.add(username, accountKey);	 
		}
		
		model.addAttribute("output", output);
		if (output.contains(OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER)) {
			return this.registry(model);
		}
		
		return "newAccount";
	}
}
