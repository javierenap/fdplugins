# Note #
**This plugin will be removed**. Next build of FlashDevelop will include this plugin as built-in



## Introduction ##

Task List plugin will add a new panel to FlashDevelop allowing you to see all the tasks defined in your project files

## Preview ##

![http://fdplugins.googlecode.com/svn/trunk/images/tasklist_preview.png](http://fdplugins.googlecode.com/svn/trunk/images/tasklist_preview.png)


## Details ##

Preferences allow you to define more words to check apart the builtin ones TODO and BUG and associate for every word an icon.
In order to define the correct image see the file Images.png into the Settings folder of your FlashDevelop installation directory, and look for the appropriate icon number.
You can define also the file extension to check during project parsing (.as, .txt, et..)

Click on "Refresh" icon on the top-right of the TaskList panel to parse again all project files.

The preferences dialog:

![http://fdplugins.googlecode.com/svn/trunk/images/tasklist_preferences.png](http://fdplugins.googlecode.com/svn/trunk/images/tasklist_preferences.png)


## Changes ##

  * Fixed the error when trying to refresh the task list with no project opened
