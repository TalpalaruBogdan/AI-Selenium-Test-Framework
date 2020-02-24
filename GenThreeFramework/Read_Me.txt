Author: Talpalaru Bogdan

A simple bare-bones selenium framework using an implementation of MCculloch-Pitts neuron model for assertions

Classes:
- Configuration => stores static data for framework level use
- Driver Helper => Stores the driver adn it's methods, as well as the performVisualAssertion() method, which will
use screenshots to perform assertions.
- ComparisonHelper => Contains the MP neuron logic to be called on by the driver in the performVisualAssertion
- FolderHelper => Manages foldrs and file creation to be used for the assertion process
- GoogleHomePage => A simple implementation of a PageObject pattern
- GoogleHomePageTests => A simple test that leverages the visual assertion

Folders:
- Resources => Contains framework resources, like the Chromedriver
- Snapshots => Stores the pictures. There are 3 sub-folders:
	- Base =>	Stores a baseline picture. If a test has not run before, the first pic will go here. If you
				are satisfied with it, keep it as a point of comparison for the next test, or delete it and create
				a new one.
	- Comparison => On the second run and so on, the framework will take a new screenshot during the test. THis will
				be compared to the base one
	- Differences => A difference picture will be created if a base picture exists. The number of differences will be 
				used to calculate the Pass/Fail