# MVPPVI2
This sample is an enhancement of the basic [MVPPVI][1] implementation and contains a couple of pre-built functions. This project should help to deploy small .NET applications quickly. The developer should not care about any additional work, like storing credentials or user data. The solution implements the basic concept of the model view presenter pattern with passive views. The passive views work great with complex view data and rely on pure unit tests. Please feel free to suggest any improvements.

- Mvp.Passive.Default.Midelware hold a collection of general logics and functions.
- Mvp.Passive.View.Base2 entry point of the application.
- Mvp.Passive.View.Base2.Midelware define the contract between presenter and view.
- Mvp.Passive.View.Base2.Model contain the data of the application.
- Mvp.Passive.View.Base2.View represent the GUI.
- Mvp.Passive.View.Base2.Presenter enclose the entire logic of the application.

[1:] https://github.com/HofmeisterAn/mvp.passive.view.base
