# Power Debug

PowerDebug is a Unity package that gives the user the ability to set a threshold for what level of message logging that should be done to the console. This is created with the intention of disuading developers from removing `Debug.Log`s from their code when they feel like their message is no longer needed because the code runs just fine. Having your program give you verbose descriptions of what's happening is your best tool for figuring out what is going on and should not be pruned because the code works at the moment. 

This package works as a wrapper, so instead of calling `Debug.Log(object message, Object context)`you should be calling `PowerDebug.Log(object message, Object context, LogThreshold)` so that you can decide the treshold of when this shall be logged and not.



## Features

- Set logging thresholds to each one of your log messages to decide at what level of verboseness it will be logged to the console.
- Set the logging verboseness in (`Edit > Preferences > PowerDebug`)

## Installation

To install PowerDebug in your Unity project, follow these steps:

1. In Unity, open the **Package Manager** window (`Window > Package Manager`)
2. Click the **Add package from git URL...** button
3. Paste the following URL in the text field: `https://github.com/AlexEnnerfelt/PowerDebug.git`
4. Click the **Add** button to add the PowerDebug package to your project

## Usage

To use PowerDebug, simply replace your `Debug.Log(object message, Object context)` with `PowerDebug.Log(object message, Object context, LogThreshold)`. You can also call this function without a log threshold and in that case it will default to the lowest threshold so that is is always logged unless you have the logger turned off. 

If you only use `Debug.Log` in a particular document, a recommendation would be to add `using Debug = PowerDebug` at the top of the document so that you can log messages with the familiar names.

## Documentation

For more detailed information on using PowerDebug, please refer to the [documentation](https://your-website.com/powerdebug/docs) on our website.

## Support

If you need help with PowerDebug, please contact us at `support@your-website.com`. We will be happy to assist you with any issues you may have.

## Contributing

We welcome contributions to PowerDebug! If you have a bug fix or new feature that you would like to contribute, please open a pull request on GitHub. For more information, please see our [contributing guidelines](https://github.com/your-username/powerdebug/blob/master/CONTRIBUTING.md).

## License

PowerDebug is released under the [MIT license](https://github.com/your-username/powerdebug/blob/master/LICENSE).
