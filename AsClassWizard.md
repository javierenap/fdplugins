# Introduction #

Similar to the Flex builder wizard class creator. It allows you to create new as2/3 classes in an easy way.


# Preview #

![http://fdplugins.googlecode.com/svn/trunk/images/asclasswizard_preview.png](http://fdplugins.googlecode.com/svn/trunk/images/asclasswizard_preview.png)


# Details #

When you choose "new class" from the project context menu the wizard dialog will be opened.
Once finished a new actionscript classes will be created according to the dialog selected options and using a modified version of the "Class.as.fdt" templates.

For example the Actionscript 3 template file is modified in this way:
```
/**
* ...
* @author Default
* @version 0.1
*/

package $(Package) $(CSLB){

	$(Import)

	$(Access)class $(FileName)$(Extends)$(Implements)$(CSLB){
		
		public function $(FileName)($(ConstructorArguments)) $(CSLB){
			$(Super)
			$(EntryPoint)
		}
		
		$(InheritedMethods)
		
	}
	
}
```