package bg.softuni.tests;


public class HtmlBuilder {

	private StringBuilder page;
	
	public StringBuilder makeBankingPage(){
		
		// Messing around with html, didn't turn out good at all... T_T
    	String doctype = this.htmlElement("!DOCTYPE", "html");
    	String meta = this.htmlElement("meta", "charset=\"UTF-8\"");
    	String title = this.htmlElementContent("Banking page homework", "title");
    	String head = this.htmlElementContent(meta + title, "head");
    	
    	String inputTextClient = this.htmlElement(
    			"input",
    			"type=\"text\"",
    			"name=\"userIdentification\"");
    	String inputRadioDeposit = this.htmlElement("input",
    			"type=\"radio\"",
    			"name=\"action\"",
    			"value=\"deposit\"") + "Deposit";
    	String inputRadioWithdraw = this.htmlElement("input",
    			"type=\"radio\"",
    			"name=\"action\"",
    			"value=\"withdraw\"") + "Withdraw";
    	String submitButton = this.htmlElement("input", 
    			"type=\"submit\"",
    			"value=\"Submit\"");
    	String newline = this.htmlElement("br");
    	
    	String form = this.htmlElementContent(
    			inputTextClient + newline + inputRadioDeposit + inputRadioWithdraw + newline + submitButton,
    			"form", "action=\"Home\"", "method=\"post\"");  
    	
    	String body = this.htmlElementContent(form, "body");    	
    	String html = this.htmlElementContent(head + body, "html");  
    	
    	this.page = new StringBuilder();
    	this.page.append(doctype).append(html);
    	
    	return page;
    	
	}
	
	private String htmlElement(String... parameters){
		
		String result = "<" + String.join(" ", parameters) + ">" + System.lineSeparator();		
		return result;
	}
	
	private String htmlElementContent(String content, String... parameters){
		
		StringBuilder result = new StringBuilder();

		result.append("<");
		result.append(String.join(" ", parameters));
		result.append(">");
		result.append(System.lineSeparator());
		result.append(content);
		result.append(System.lineSeparator());
		result.append("</");
		// Using the first parameter for the type of element, not good at all... :D
		result.append(parameters[0]);
		result.append(">");
		result.append(System.lineSeparator());
		
		return result.toString();
	}
}
